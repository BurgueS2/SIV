using System;
using System.Windows.Forms;

namespace SIV.Helpers;

/// <summary>
/// A classe é responsável por centralizar a exibição de mensagens ao usuário, utilizando caixas de diálogo do Windows Forms.
/// Ela oferece métodos estáticos para exibir mensagens de sucesso, erro, e confirmação.
/// </summary>
public class MessageHelper
{
    /// <summary>
    /// Exibe uma mensagem de sucesso ao salvar um registro.
    /// </summary>
    public static void ShowSaveSuccessMessage()
    {
        MessageBox.Show(@"Registro salvo com sucesso!", @"REGISTRO SALVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Exibe uma mensagem de sucesso ao atualizar um registro.
    /// </summary>
    public static void ShowUpdateSuccessMessage()
    {
        MessageBox.Show(@"Registro atualizado com sucesso!", @"REGISTRO ATUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    /// <summary>
    /// Exibe uma mensagem de sucesso ao excluir um registro.
    /// </summary>
    public static void ShowDeleteSuccessMessage()
    {
        MessageBox.Show(@"Registro excluído com sucesso!", @"REGISTRO EXCLUÍDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    /// <summary>
    /// Exibe uma mensagem de alerta quando um CPF já cadastrado é detectado.
    /// </summary>
    public static void ShowRegisteredCpfMessage()
        {
            MessageBox.Show( @"CPF já cadastrado", @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    
    /// <summary>
    /// Exibe uma mensagem de erro personalizada, baseada na exceção capturada e na ação que estava sendo realizada.
    /// </summary>
    /// <param name="ex">A exceção capturada durante a operação.</param>
    /// <param name="action">A ação que estava sendo realizada, para contextualizar a mensagem de erro.</param>
    public static void ShowErrorMessage(Exception ex, string action)
    {
        var message = $"Erro ao {action} no banco de dados:\n{ex.Message}";
        MessageBox.Show(message, @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Exibe uma caixa de diálogo de confirmação para a exclusão de um registro.
    /// </summary>
    /// <returns>Indicando a escolha do usuário ('true' para sim 'false' para não).</returns>
    public static bool ConfirmDeletion()
    {
        var questioning = MessageBox.Show( @"Deseja excluir o registro?", @"EXCLUIR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        return questioning == DialogResult.Yes;
    }
    
    /// <summary>
    /// Exibe uma mensagem de alerta com o resultado da validação.
    /// </summary>
    /// <param name="validationResult">O resultado da validação a ser exibido.</param>
    public static void ShowValidationMessage(string validationResult)
    {
        MessageBox.Show(validationResult, @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    
    /// <summary>
    /// Exibe uma mensagem de alerta informando que o cargo já está cadastrado.
    /// </summary>
    public static void ShowJobExistMessage(string jobExist)
    {
        MessageBox.Show(@$"O cargo '{jobExist}' já está cadastrado.", @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    
    /// <summary>
    /// Exibe uma mensagem de alerta solicitando a seleção de um cargo.
    /// </summary>
    /// <param name="message">A ação que está sendo realizada.</param>
    public static void ShowMessageJob(string message)
    {
        MessageBox.Show(@$"Por favor, selecione um cargo para {message}", @"ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    
    /// <summary>
    /// Exibe uma mensagem de erro ao tentar carregar uma imagem com memória insuficiente.
    /// </summary>
    public static void ShowInsufficientMemory()
    {
        MessageBox.Show(@"Memória insuficiente para carregar a imagem. Tente uma imagem menor.", @"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    /// <summary>
    /// Exibe uma caixa de diálogo de confirmação para sair do sistema.
    /// </summary>
    public static bool ConfirmExit()
    {
        var questioning = MessageBox.Show(@"Deseja sair do sistema?", @"SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        return questioning == DialogResult.Yes;
    }
    
    /// <summary>
    /// Exibe uma mensagem de alerta informando que o email já existe e pergunta se deseja salvar mesmo assim.
    /// </summary>
    /// <returns>Indicando a escolha do usuário ('true' para sim 'false' para não).</returns>
    public static bool ShowEmailExistMessage()
    {
        var questioning = MessageBox.Show(@"Esse E-Mail já existe deseja salvar mesmo assim?", @"EMAIL EXISTENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        return questioning == DialogResult.Yes;
    }
}