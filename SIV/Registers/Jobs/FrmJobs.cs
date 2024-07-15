using System;
using System.Windows.Forms;

namespace SIV.Registers.Jobs;

public partial class FrmJobs : MetroFramework.Forms.MetroForm
{
    private string _id;
    public FrmJobs()
    {
        InitializeComponent();
    }
    
    private void FrmJobs_Load(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        LoadJobs();
        btnNew.Enabled = true;
        dgvJobs.Columns[1].HeaderText = @"NOME";
    }
    
    private void dgvJobs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgvJobs.SelectedRows.Count <= 0) return;
        
        ConfigureUiControls(true); // Habilita os campos do formulário
        btnSave.Enabled = false;
        
        // Supondo que a primeira coluna do DataGridView contém o ID do cargo
        _id = dgvJobs.SelectedRows[0].Cells[0].Value.ToString();
        txtName.Text = dgvJobs.CurrentRow?.Cells[1].Value.ToString();
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(true);
        txtName.Focus();
        
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
        dgvJobs.Enabled = false;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ConfigureUiControls(false);
        txtName.Clear();
        dgvJobs.Enabled = true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var repository = new JobRepository();
            repository.SaveJob(txtName.Text);
            
            MessageBox.Show(this, @"Registro salvo com sucesso!", @"CADASTRO SALVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ConfigureUiControls(false);
            txtName.Clear();
        }
        catch (Exception ex)
        {
            HandleException(ex, "Erro ao salvar no banco de dados:");
        }
        finally
        {
            ConnectionManager.CloseConnection();
            LoadJobs();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_id))
        {
            MessageBox.Show(this, @"Por favor, selecione um cargo para editar.", @"Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var repository = new JobRepository();
            repository.UpdateJob(_id, txtName.Text);
            
            MessageBox.Show(this, @"Registro atualizado com sucesso!", @"CADASTRO ATUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ConfigureUiControls(false);
            txtName.Clear();
        }
        catch (Exception ex)
        {
            HandleException(ex, "Erro ao atualizar no banco de dados:");
        }
        finally
        {
            ConnectionManager.CloseConnection();
            LoadJobs();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var questioning = MessageBox.Show(this, @"Deseja excluir o registro?", @"EXCLUIR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (questioning == DialogResult.Yes)
        {
            try
            {
                var repository = new JobRepository();
                repository.DeleteJob(_id);
                MessageBox.Show(this, @"Registro excluído com sucesso!", @"REGISTRO EXCLUÍDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ConfigureUiControls(false);
                txtName.Clear();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Erro ao excluir no banco de dados:");
            }
            finally
            {
                ConnectionManager.CloseConnection();
                LoadJobs(); // Atualiza a interface do usuário após excluir
            }
        }
    }

    private void LoadJobs()
    {
        var repository = new JobRepository();
        var dt = repository.GetAllJobs();
        dgvJobs.DataSource = dt;
        dgvJobs.Columns[0].Visible = false; // Esconde a primeira coluna do DataGridView
    }
    
    
    private void HandleException(Exception ex, string customMessage)
    {
        var message = string.IsNullOrWhiteSpace(customMessage) ? "Um erro inesperado ocorreu." : customMessage;
        message += $"\nDetalhe do Erro: {ex.Message}"; // Concatena a mensagem de erro com a mensagem personalizada
        
        MessageBox.Show(this, message, @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    
    private void ConfigureUiControls(bool enable)
    {
        btnNew.Enabled = !enable;
        btnSave.Enabled = enable;
        btnEdit.Enabled = enable;
        btnDelete.Enabled = enable;
        btnCancel.Enabled = enable;
        txtName.Enabled = enable;
        dgvJobs.Enabled = !enable;
    }
}