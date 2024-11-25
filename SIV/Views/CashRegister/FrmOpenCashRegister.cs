using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using SIV.Core;
using SIV.Helpers;
using SIV.Repositories;

namespace SIV.Views.CashRegister;

public partial class FrmOpenCashRegister : Form
{
    public decimal OpeningAmount { get; private set; } // Valor de abertura do caixa
    private readonly string _userName;
    private readonly int _userId;
    
    public FrmOpenCashRegister()
    {
        InitializeComponent();
        _userName = SessionManager.CurrentUser.Name;
        _userId = int.Parse(SessionManager.CurrentUser.Id);
    }
    
    private void FrmOpenCashRegister_Load(object sender, EventArgs e)
    {
        labelTimeStatusBar.Text = DateTime.Now.ToString("HH:mm:ss");
        labelDateStatusBar.Text = DateTime.Today.ToString("dd/MMMM/yyyy");
        txtUser.Text = _userName; // Exibe o nome do usuário logado
        LoadUsers();
    }
    
    private void btnOk_Click(object sender, EventArgs e) => OpenCashRegister();
    
    private void btnOpen_Click(object sender, EventArgs e) => OpenCashRegister();
    
    private void btnCancel_Click(object sender, EventArgs e) => ClearAmountTextBox();
    
    private void btnBackspace_Click(object sender, EventArgs e) =>RemoveLastCharacter(txtAmount);
    
    private void NumberButton_Click(object sender, EventArgs e)
    {
        // Verifica se o objeto que disparou o evento é um botão
        if (sender is Guna2Button btn)
        {
            AppendText(txtAmount, btn.Text); // Coloca o número do botão no campo de texto
        }
    }
    
    private static void AppendText(Guna2TextBox textBox, string text)
    {
        textBox.Text += text;
    }
    
    private static void RemoveLastCharacter(Guna2TextBox textBox)
    {
        if (textBox.Text.Length > 0)
        {
            textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
        }
    }
    
    private void OpenCashRegister()
    {
        if (decimal.TryParse(txtAmount.Text, out var amount)) 
        {
            OpeningAmount = amount;
            DialogResult = DialogResult.OK;
            ClearAmountTextBox();
            CashRegisterRepository.OpenCashRegister(_userId, _userName, amount);
            CashRegisterRepository.GetAllUser(); // Atualiza a lista de usuários após abrir o caixa
            MessageHelper.BoxOpenSuccessMessage();
        }
        else
        {
            MessageHelper.ShowValidationMessage("O valor informado é inválido.");
        }
    }
    
    private void LoadUsers()
    {
        try
        {
            gridData.DataSource = CashRegisterRepository.GetAllUser();
            FormatGridData();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            MessageHelper.HandleException(ex, "carregar os dados dos usuários");
        }
    }
    
    private void FormatGridData()
    {
        if (gridData.Columns.Count > 0) gridData.Columns[0].Visible = false;
        if (gridData.Columns.Count > 1) gridData.Columns[1].Visible = false;
        if (gridData.Columns.Count > 2) gridData.Columns[2].HeaderText = @"Usuário";
        if (gridData.Columns.Count > 3) gridData.Columns[3].HeaderText = @"Caixa";
        if (gridData.Columns.Count > 4) gridData.Columns[4].HeaderText = @"Data de abertura";
        if (gridData.Columns.Count > 5) gridData.Columns[5].HeaderText = @"Data de fechamento";
    }
    
    private void ClearAmountTextBox()
    {
        txtAmount.Clear();
        txtAmount.Focus();
    }
}