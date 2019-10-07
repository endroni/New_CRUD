using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;

namespace Sistema.View
{
    public partial class frmCadUsuario : Form
    {
        UsuarioEnt objTabela = new UsuarioEnt();
        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void txtNovo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            iniciarOpc();
        }

        private string opc = ""; 
               
        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        objTabela.Nome = txtNome.Text;
                        objTabela.Usuario = txtUsuario.Text;
                        objTabela.Senha = txtSenha.Text;

                        int x = UsuarioModel.Inserir(objTabela);

                        if(x > 0)
                        {
                            MessageBox.Show(String.Format("Usuário {0} inserido com sucesso", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Sado não inserido");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro" + ex.Message);
                        throw;
                    }
                    break;

                case "Excluir":
                    break;

                case "Editar":
                    break;
                
            }
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }

        private void txtSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            iniciarOpc();
        }

        private void txtExcluir_Click(object sender, EventArgs e)
        {
            opc = "Excluir";
            iniciarOpc();
        }

        private void txtEditar_Click(object sender, EventArgs e)
        {
            opc = "Editar";
            iniciarOpc();
        }
        
        private void ListarGrid()
        {
            try
            {
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModel().lista();
                grid.DataSource = lista;
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Listar Dados" + ex.Message);
            }
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }
    }
}
