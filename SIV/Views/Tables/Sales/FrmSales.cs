using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Core;
using SIV.Helpers;
using SIV.Models;
using SIV.Repositories;
using SIV.Views.CashRegister;
using SIV.Views.Tables.ProductData;
using SIV.Views.Tables.TableOrItemTransfer;

namespace SIV.Views.Tables.Sales;

public partial class FrmSales : Form
{
    private const double BrightnessFactor = 0.5; // Fator de brilho para a cor de destaque.
    private int _tableId;
    private readonly string _userName;
    private Table _table; // Instância da mesa. 
    
    public FrmSales()
    {
        InitializeComponent();
        _userName = SessionManager.CurrentUser.Name;
        labelUser.Text = $@"Usuário: {_userName}";
    }
    
    private void FrmSales_Load(object sender, EventArgs e) => ApplyTheme();
    
    private void btnSale_Click(object sender, EventArgs e) => EnableSaleControls();
    
    private void btnCancelProduct_Click(object sender, EventArgs e) => CancelSelectedProduct();
    
    private void btnItemTransfer_Click(object sender, EventArgs e) { /* TODO: Implementar lógica de transferência de item */ }
    
    private void btnTableTransfer_Click(object sender, EventArgs e) => OpenForm(new FrmTableTransfer(0), btnTableTransfer);
    
    private void btnItemRelease_Click(object sender, EventArgs e) { /* TODO: Implementar lógica de lançamento de caixa */ }
    
    private void btnCloseCashRegister_Click(object sender, EventArgs e) { /* TODO: Implementar lógica de fechamento de caixa */ }
    
    private void btnConf_Click(object sender, EventArgs e) { /* TODO: Implementar lógica de configuração */ }
    
    private void btnSearchProduct_Click(object sender, EventArgs e) => SearchProduct();
    
    private void btnOpenCashRegister_Click(object sender, EventArgs e) => OpenCashRegister();
    
    private void btnOk_Click(object sender, EventArgs e) { if (IsProductInputValid())  SaveProductToTable(); }
    
    private void txtProduct_TextChanged(object sender, EventArgs e) => UpdateProductNameLabel(txtProduct.Text);
    
    private void timer_Tick(object sender, EventArgs e) => UpdateStatusBar();
    
    private void txtSale_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        HandleTableInput(); // Lida com a entrada de dados da mesa.
        InitializeForm();
        e.Handled = true;
        e.SuppressKeyPress = true;
    }
    
    private void txtProduct_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        HandleProductSearch(); // Lida com a entrada de dados do produto.
        e.Handled = true;
        e.SuppressKeyPress = true;
    }
    
    private void InitializeForm()
    {
        try
        {
            labelUser.Text = $@"Usuário: {_userName}"; // Exibe o nome do usuário logado.
            _table = TableRepository.LoadTable(_tableId);
            LoadTableProducts();
            txtSearchUser.Text = _userName; // Preenche o campo de texto com o nome do usuário logado.
            txtClient.Text = @"Passante";
            labelDateStatus.Text = _table.SaveDate?.ToString("dd/mm/yyyy");
            labelTimeStatus.Text = _table.SaveTime.ToString();
            LengthOfStay();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "inicializar formulário de vendas");
        }
    }
    
    private void LoadTableProducts()
    {
        try
        {
            gridData.DataSource = TableRepository.GetTableProducts(_tableId);
            UpdateTotalValueLabel();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar produtos da mesa");
        }
    }
    
    private void FormatGridData()
    {
        gridData.Columns[0].Visible = false;
        gridData.Columns[1].HeaderText = @"Produto";
        gridData.Columns[2].HeaderText = @"Preço";
        gridData.Columns[3].HeaderText = @"Qtd.";
        gridData.Columns[4].HeaderText = @"Garçom";
        
        // Oculta as linhas sem produtos.
        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Cells["ProductName"].Value?.ToString()))
            {
                row.Visible = false;
            }
        }
    }
    
    private void UpdateTotalValueLabel()
    {
        decimal totalValue = 0;
        
        // Calcula o valor total dos produtos.
        foreach (DataGridViewRow row in gridData.Rows)
        {
            if (row.Cells["ProductPrice"].Value != null)
            {
                totalValue += Convert.ToDecimal(row.Cells["ProductPrice"].Value) * Convert.ToDecimal(row.Cells["Amount"].Value);
            }
        }
        
        labelValue.Text = totalValue.ToString("C");
    }
    
    private void OpenForm(Form form, object senderButton)
    {
        ActivateButton(senderButton);
        // _enableFormDisplay = form;
        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;
        
        panelDisplayForm.Controls.Add(form);
        panelDisplayForm.Tag = form;
        
        form.BringToFront();
        form.Show();
    }
    
    private void ActivateButton(object senderButton)
    {
        var color = ColorThemes.PrimaryColor;
        ResetButtons(color);
        var currentButton = (Guna2Button)senderButton;
        
        currentButton.FillColor = color;
        currentButton.ForeColor = Color.Black;
        currentButton.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
        
        panelStatusv.BackColor = ColorThemes.ChangeBrightness(color, BrightnessFactor); // Altera o brilho do painel de status.
    }
    
    private void ResetButtons(Color color)
    {
        // Altera a cor de todos os botões do painel.
        foreach (Control control in panelStatusv.Controls)
        {
            if (control is not Guna2Button button) continue;
            
            button.FillColor = ColorThemes.ChangeBrightness(color, BrightnessFactor);
            button.ForeColor = Color.Black;
            button.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular);
        }
    }
    
    private void ApplyTheme()
    {
        var fillColor = ColorThemes.ChangeBrightness(ColorThemes.PrimaryColor, 0.5);
        
        panelStatusv.BackColor = fillColor;
        ApplyThemeToControl(btnSale, fillColor);
        ApplyThemeToControl(btnItemTransfer, fillColor);
        ApplyThemeToControl(btnTableTransfer, fillColor);
        ApplyThemeToControl(btnItemRelease, fillColor);
        ApplyThemeToControl(btnConf, fillColor);
        ApplyThemeToControl(btnCancelProduct, fillColor);
        ApplyThemeToControl(btnOpenCashRegister, fillColor);
        ApplyThemeToControl(btnCloseCashRegister, fillColor);
    }
    
    private static void ApplyThemeToControl(Control control, Color fillColor)
    {
        if (control is Guna2Button button)
        {
            button.FillColor = fillColor;
        }
    }
    
    private void UpdateStatusBar()
    {
        labelTimeStatusBar.Text = DateTime.Now.ToString("HH:mm:ss");
        labelDateStatusBar.Text = DateTime.Today.ToString("dd/MM/yyyy");
    }
    
    private void numericAmount_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        
        SaveProductToTable();
        e.Handled = true;
        e.SuppressKeyPress = true;
    }
    
    /// <summary>
    /// Lida com a busca de um produto no banco de dados.
    /// </summary>
    private void HandleProductSearch()
    {
        var productName = txtProduct.Text;
        var product = ProductRepository.GetProductByName(productName);
        
        if (product != null)
        {
            UpdateProductNameLabel(productName);
            txtCost.Text = product.ResalePrice.ToString("C");
            numericAmount.Value = 1;
            numericAmount.Focus();
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }
    
    private void SaveProductToTable()
    {
        var productName = txtProduct.Text;
        var amount = numericAmount.Value;

        if (IsProductInputValid())
        {
            try
            {
                var product = ProductRepository.GetProductByName(productName);
                if (product == null) return;

                TableRepository.AddProductToTable(_tableId, product.Name, product.ResalePrice, amount, _userName);
                TableRepository.UpdateTableState(_tableId, "Ocupada", "Khaki");
                LoadTableProducts();
                ResetProductInputFields();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                MessageHelper.HandleException(ex, "adicionar produto");
            }
        }
        else
        {
            MessageHelper.ShowInvalidProductOrQuantity();
        }
    }
    
    /// <summary>
    /// Verifica se o nome do produto e a quantidade são válidos.
    /// </summary>
    /// <returns>'true' se o nome do produto e a quantidade forem válidos, 'false' caso contrário.</returns>
    private bool IsProductInputValid()
    {
        return !string.IsNullOrWhiteSpace(txtProduct.Text) && numericAmount.Value > 0; // Verifica se o nome do produto e a quantidade são válidos.
    }
    
    /// <summary>
    /// Atualiza o nome do produto exibido no formulário.
    /// </summary>
    /// <param name="partialProductName">O nome do produto a ser buscado.</param>
    private void UpdateProductNameLabel(string partialProductName)
    {
        var product = ProductRepository.GetProductByName(partialProductName);
        
        if (product != null)
        {
            labelNameProduct.Text = product.Name;
            labelNameProduct.Visible = true;
        }
        else // Caso o produto não seja encontrado no banco de dados (ou o nome seja inválido).
        {
            labelNameProduct.Visible = false;
        }
    }
    
    private void ResetProductInputFields()
    {
        txtProduct.Clear();
        txtCost.Text = @"0,00";
        numericAmount.Value = 1;
        txtProduct.Focus();
    }
    
    private void SearchProduct()
    {
        var frmProductData = new FrmProductData();
        
        if (frmProductData.ShowDialog() != DialogResult.OK) return;
        
        txtProduct.Text = frmProductData.SelectedProduct;
        txtCost.Text = frmProductData.CostPrice;
        numericAmount.Value = 1;
    }
    
    /// <summary>
    /// Verifica se o caixa já está aberto e, caso não esteja, abre o formulário de abertura de caixa.
    /// </summary>
    private void OpenCashRegister()
    {
        if (!CashRegisterRepository.IsCashRegisterAlreadyOpen(int.Parse(SessionManager.CurrentUser.Id)))
        {
            OpenForm(new FrmOpenCashRegister(), btnOpenCashRegister);
        }
        else
        {
            MessageHelper.BoxIsAlreadyOpenMessage();
        }
    }
    
    private void EnableSaleControls()
    {
        txtSale.Enabled = true;
        txtSale.Focus();
        btnCancelProduct.Enabled = true;
        txtClient.Enabled = true;
        txtSearchUser.Enabled = true;
        btnSearchUser.Visible = true;
        numericAmount.Enabled = true;
        btnSearchProduct.Visible = true;
    }
    
    private void CancelSelectedProduct()
    {
        if (!MessageHelper.ConfirmDeletion()) return;
        
        if (gridData.SelectedRows.Count > 0)
        {
            var selectedRow = gridData.SelectedRows[0]; // Obtém a linha selecionada.
            
            if (int.TryParse(selectedRow.Cells["EntryId"].Value.ToString(), out var productId)) // Obtém o ID do produto.
            {
                TableRepository.RemoveProductFromTable(_tableId, productId);
                LoadTableProducts();
            }
            else
            {
                MessageBox.Show(@"Erro ao obter o ID do produto.");
            }
        }
        else
        {
            MessageHelper.ShowProductNotFound();
        }
    }
    
    /// <summary>
    /// Lida com a entrada de dados da mesa no campo de texto.
    /// o ID da mesa é obtido e, caso seja válido, as informações da mesa são carregadas.
    /// </summary>
    private void HandleTableInput()
    {
        try
        {
            var input = txtSale.Text;
        
            if (int.TryParse(input, out var tableId))
            {
                var table = TableRepository.LoadTable(tableId);
                
                if (table.State == "Fechada")
                {
                    MessageHelper.ShowValidationMessage("A mesa está fechada. Por favor, abra a mesa antes de realizar a venda.");
                    return;
                }
                
                MessageBox.Show(@$"A mesa {tableId} está {table.State}.");
                
                _tableId = tableId;
                LoadTableProducts();
            }
            else
            {
                MessageHelper.ShowValidationMessage("O número da mesa é inválido. Por favor, tente novamente.");
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "lidar com entrada de mesa");
        }
    }
    
    private void LengthOfStay()
    {
        try
        {
            if (!_table.SaveTime.HasValue) return;
            
            var duration = DateTime.Now - _table.SaveTime.Value;
            labelStayHours.Text = duration.ToString("HH:mm:ss");
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "calcular duração da estadia");
        }
    }
}