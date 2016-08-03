using Library.Persistencia_DbCentral;
using Library.Persistencia_DbCentral.Models;
using Prova.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prova
{
    public partial class FormAdm : Form
    {
        private DbCentralContext ctx;
        public FormAdm()
        {
            InitializeComponent();
            InitializeComponentAval();
            ctx = new DbCentralContext();
        }

        #region EVENTS

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void FormAdm_Load(object sender, EventArgs e)
        {
            //  timer1_Tick(e, e);
            this.BackgroundImage = Resources.fundos_A5_fichas_laranja;

            #region  Initial Prova Setup

            //Questionario q = new Questionario() { Prova = "Ano1_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q);
            //Questionario q1 = new Questionario() { Prova = "Ano1_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q1);
            //Questionario q8 = new Questionario() { Prova = "Ano1_MAT_A", Descricao = "" };
            //ctx.Questionarios.Add(q8);
            //Questionario q11 = new Questionario() { Prova = "Ano1_MAT_B", Descricao = "" };
            //ctx.Questionarios.Add(q11);
            //Questionario q12 = new Questionario() { Prova = "Ano1_LP_A", Descricao = "" };
            //ctx.Questionarios.Add(q12);
            //Questionario q13 = new Questionario() { Prova = "Ano1_LP_B", Descricao = "" };
            //ctx.Questionarios.Add(q13);

            //Questionario qdd = new Questionario() { Prova = "Ano2_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(qdd);
            //Questionario q1dd = new Questionario() { Prova = "Ano2_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q1dd);
            //Questionario q8dd = new Questionario() { Prova = "Ano2_MAT_A", Descricao = "" };
            //ctx.Questionarios.Add(q8dd);
            //Questionario q11dd = new Questionario() { Prova = "Ano2_MAT_B", Descricao = "" };
            //ctx.Questionarios.Add(q11dd);
            //Questionario q12dd = new Questionario() { Prova = "Ano2_LP_A", Descricao = "" };
            //ctx.Questionarios.Add(q12dd);
            //Questionario q13dd = new Questionario() { Prova = "Ano2_LP_B", Descricao = "" };
            //ctx.Questionarios.Add(q13dd);

            //Questionario qddd = new Questionario() { Prova = "Ano3_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(qddd);
            //Questionario q1ddd = new Questionario() { Prova = "Ano3_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q1ddd);
            //Questionario q8ddd = new Questionario() { Prova = "Ano3_MAT_A", Descricao = "" };
            //ctx.Questionarios.Add(q8ddd);
            //Questionario q11ddd = new Questionario() { Prova = "Ano3_MAT_B", Descricao = "" };
            //ctx.Questionarios.Add(q11ddd);
            //Questionario q12ddd = new Questionario() { Prova = "Ano3_LP_A", Descricao = "" };
            //ctx.Questionarios.Add(q12ddd);
            //Questionario q13ddd = new Questionario() { Prova = "Ano3_LP_B", Descricao = "" };
            //ctx.Questionarios.Add(q13ddd);

            /////////////////////////////////////////////////////////////////////////////////////

            //Questionario q5 = new Questionario() { Prova = "Ano1_LP_MAT_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q5);

            //Questionario q6 = new Questionario() { Prova = "Ano1_LP_MAT_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q6);

            //Questionario q7aa = new Questionario() { Prova = "Ano1_LP_MAT_A", Descricao = "" };
            //ctx.Questionarios.Add(q7aa);

            //Questionario q7aaa = new Questionario() { Prova = "Ano1_LP_MAT_B", Descricao = "" };
            //ctx.Questionarios.Add(q7aaa);

            //Questionario q7aaqq = new Questionario() { Prova = "Ano1_LP_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q7aaqq);

            //Questionario q7aaaqq = new Questionario() { Prova = "Ano1_LP_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q7aaaqq);
            
            //Questionario q9 = new Questionario() { Prova = "Ano1_MAT_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q9);

            //Questionario q10 = new Questionario() { Prova = "Ano1_MAT_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q10);
            
            //Questionario q5t = new Questionario() { Prova = "Ano2_LP_MAT_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q5t);

            //Questionario q6t = new Questionario() { Prova = "Ano2_LP_MAT_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q6t);

            //Questionario q7aat = new Questionario() { Prova = "Ano2_LP_MAT_A", Descricao = "" };
            //ctx.Questionarios.Add(q7aat);

            //Questionario q7aaat = new Questionario() { Prova = "Ano2_LP_MAT_B", Descricao = "" };
            //ctx.Questionarios.Add(q7aaat);

            //Questionario q7aaqqt = new Questionario() { Prova = "Ano2_LP_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q7aaqqt);

            //Questionario q7aaaqqt = new Questionario() { Prova = "Ano2_LP_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q7aaaqqt);

            //Questionario q9t = new Questionario() { Prova = "Ano2_MAT_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q9t);

            //Questionario q10t = new Questionario() { Prova = "Ano2_MAT_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q10t);

            
            //Questionario q5tx = new Questionario() { Prova = "Ano3_LP_MAT_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q5tx);

            //Questionario q6tx = new Questionario() { Prova = "Ano3_LP_MAT_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q6tx);

            //Questionario q7aatx = new Questionario() { Prova = "Ano3_LP_MAT_A", Descricao = "" };
            //ctx.Questionarios.Add(q7aatx);

            //Questionario q7aaatx = new Questionario() { Prova = "Ano3_LP_MAT_B", Descricao = "" };
            //ctx.Questionarios.Add(q7aaatx);

            //Questionario q7aaqqtx = new Questionario() { Prova = "Ano3_LP_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q7aaqqtx);

            //Questionario q7aaaqqtx = new Questionario() { Prova = "Ano3_LP_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q7aaaqqtx);

            //Questionario q9tx = new Questionario() { Prova = "Ano3_MAT_APR_A", Descricao = "" };
            //ctx.Questionarios.Add(q9tx);

            //Questionario q10tx = new Questionario() { Prova = "Ano3_MAT_APR_B", Descricao = "" };
            //ctx.Questionarios.Add(q10tx);

            //ctx.SaveChanges();

            #endregion

        }


        //AVAL
        private void rdNewAval_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNewAval.Checked == true)
            {
                ResetNewAvals();
            }
        }
        private void rdAvalList_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAvalList.Checked == true)
            {
                ResetAvalList();
            }
        }
        private void cmbEspAval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspAval.SelectedValue is int)
            {
                int i = (int)cmbEspAval.SelectedValue;
                LoadCmbPacAval(i);
                cmbPacAval.Text = "";
                cmbAval.Text = "";
                dgvAvalsPac.DataSource = null;
            }
        }
        private void cmbPacAval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPacAval.SelectedValue is int)
            {
                int i = (int)cmbPacAval.SelectedValue;
                LoadDgvAvalsPac(i);
            }
        }


        //Especialista
        private void rdAdicEsp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAdicEsp.Checked == true)
            {
                lblNomeEsp.Text = "Nome do Especialista";
                btnExecEsp.Text = "Cadastrar";
                txtEsp.Enabled = true;
                txtEsp.Text = "";
                txtEsp.Focus();
            }
        }
        private void rdUpdEsp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdUpdEsp.Checked == true)
            {
                lblNomeEsp.Text = "Alteração";
                btnExecEsp.Text = "Alterar";
                txtEsp.Enabled = true;
                txtEsp.Text = "";
                txtEsp.Focus();
            }
        }
        private void rdDelEsp_CheckedChanged(object sender, EventArgs e)
        {

            if (rdDelEsp.Checked == true)
            {
                lblNomeEsp.Text = "Exclusão";
                txtEsp.Text = "";
                txtEsp.Enabled = false;
                btnExecEsp.Text = "Excluir";
                lstEsp.Focus();
            }

        }
        private void lstEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEsp.Items.Count > 0)
            {
                txtEsp.Text = lstEsp.GetItemText(lstEsp.SelectedItem);
            }
        }
        private void btnExecEsp_Click(object sender, EventArgs e)
        {
            if (rdAdicEsp.Checked == true)
            {
                if (txtEsp.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Preencher nome do especialista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                AddEsp(txtEsp.Text.Trim());
               

            }
            else if (rdUpdEsp.Checked == true)
            {
                if (txtEsp.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Preencher nome do especialista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                UpdEsp((int)lstEsp.SelectedValue, txtEsp.Text.Trim());
            }
            else
            {
                if (lstEsp.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecionar nome na lista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                RemoveEsp((int)lstEsp.SelectedValue);
            }

            LoadLstEsp();
            txtEsp.Text = "";
        }

        //Paciente
        private void rdAddPac_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAddPac.Checked == true)
            {
                pnlAdicPac.Visible = true;
                pnlUpdPac.Visible = false;
                pnlDelPac.Visible = false;
                ResetCtrlsAdd();
            }


        }
        private void rdUpdPac_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdUpdPac.Checked == true)
            {
                pnlAdicPac.Visible = false;
                pnlUpdPac.Visible = true;
                pnlDelPac.Visible = false;
                btnExecPac.Text = "Alterar";
                                
                LoadEspUpdPac();
                cmbEspUpdPac.SelectedIndex = -1;
                cmbPacPac.DataSource = null;
                ResetCtrlsUpd();
         }

        }
        private void rdDelPac_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rdDelPac.Checked == true)
            {
                pnlAdicPac.Visible = false;
                pnlUpdPac.Visible = false;
                pnlDelPac.Visible = true;
                btnExecPac.Text = "Excluir";
                LoadDgvDelPac();
            }

        }
        private void cmbEspUpdPac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspUpdPac.SelectedValue is int)
            {
                int i = (int)cmbEspUpdPac.SelectedValue;
                LoadCmbPacPac(i);
                cmbPacPac.Text = "";
                cmbPacPac.SelectedIndex = -1;
            }
        }
        private void cmbPacPac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPacPac.SelectedValue is int)
            {
                int i = (int)cmbPacPac.SelectedValue;
                LoadPacDetails(i);
            }

        }

        private void btnExecPac_Click(object sender, EventArgs e)
        {
            if (rdAddPac.Checked == true)
            {
                #region validacao

                if (cmbEspAddPac.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecionar Especialista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtAddPac.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Preencher nome da Criança", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (rdAddSexoM.Checked == false && rdAddSexoF.Checked == false)
                {
                    MessageBox.Show("Selecionar sexo", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                #endregion

                AddPac((int)cmbEspAddPac.SelectedValue, txtAddPac.Text.Trim(), dtpAddPac.Value, rdAddSexoM.Checked == true ? "M" : "F");
                cmbEspAddPac.Text = "";
                txtAddPac.Text = "";
                dtpAddPac.Value = DateTime.Now;
                rdAddSexoF.Checked = false;
                rdAddSexoM.Checked = false;
            }
            else if (rdUpdPac.Checked == true)
            {
                #region validacao

                if (cmbEspUpdPac.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecionar especialista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cmbPacPac.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecionar Criança", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (rdUpdSexoM.Checked == false && rdUpdSexoF.Checked == false)
                {
                    MessageBox.Show("Selecionar sexo", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtUpdPac.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Preencher alteração", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                #endregion

                UpdatePac((int)cmbEspUpdPac.SelectedValue, (int)cmbPacPac.SelectedValue, txtUpdPac.Text.Trim(), dtpUpdPac.Value, rdUpdSexoM.Checked == true ? "M" : "F");
                cmbPacPac.DataSource = null;
                ResetCtrlsUpd();

            }
            else
            {

                if (dgvDelPac.SelectedRows.Count == 0)
                    {
                    MessageBox.Show("Selecionar Criança", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var id = dgvDelPac.SelectedRows[0].Cells[0].Value; 
                RemovePac((int)id);
                LoadDgvDelPac();

            }
        }

        //TABS !!!!!!!!!!!!!!!!!!!!!
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    //Inst

                    break;

                case 1:
                    //Nom

                    break;

                case 2:
                    //Aval
                    ResetAvalList();

                    break;
                case 3:
                    //Esp
                    LoadLstEsp();
                    rdAdicEsp.Checked = true;
                    btnExecEsp.Text = "Cadastrar";
                    txtEsp.Text = "";

                    break;
                case 4:
                    //Pac
                    rdAddPac.Checked = true;
                    ResetCtrlsAdd();
    
                    break;
                case 5:
                    //Opc

                    break;


                default:
                    break;
            }


        }

        #endregion

        #region METHODS

        // LOADing Controls /////////////////////////////////////////

        // TAB AVALIACAO
        public void LoadCmbEspAval()
        {
            cmbEspAval.DataSource = null;
            cmbEspAval.DataSource = LoadEsp();
            cmbEspAval.DisplayMember = "Nome";
            cmbEspAval.ValueMember = "id";
        }
        public void LoadCmbPacAval(int espId)
        {
            cmbPacAval.DataSource = null;
            cmbPacAval.DataSource = LoadPac(espId);
            cmbPacAval.DisplayMember = "Nome";
            cmbPacAval.ValueMember = "id";
          
        }
        public void ResetAvalList()
        {
            pnlAvals.Visible = true;
            rdAvalList.Checked = true;
            pnlBtns.Location = new Point(279, 297);
    
            LoadCmbEspAval();
            cmbPacAval.DataSource = null;
            dgvAvalsPac.DataSource = null;
            cmbEspAval.Text = "";
            cmbEspAval.Focus();
        }
        public void ResetNewAvals()
        {
            pnlAvals.Visible = false;
            pnlBtns.Location = new Point(30, 214);

            cmbAval.Text = "";
            cmbPacAval.DataSource = null;
            cmbEspAval.Text = "";
            cmbEspAval.Focus();

        }

        public void LoadDgvAvalsPac(int idPac)
        {
            dgvAvalsPac.DataSource = null;
            var data = LoadLstAval(idPac);
            if (data == null) return;

            var dataTable = new DataTable();
            dataTable.Columns.Add("idAval", typeof(int));
            dataTable.Columns.Add("idProva", typeof(int));
            dataTable.Columns.Add("Prova", typeof(string));
            dataTable.Columns.Add("DtInício", typeof(string));
            dataTable.Columns.Add("DtFim", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));

            DataRow row = null;

            foreach (var rowObj in data)
            {
                row = dataTable.NewRow();
                dataTable.Rows.Add(rowObj.idAval, rowObj.idProva, rowObj.Prova, rowObj.DtIni, rowObj.DtIFim, rowObj.Status);
            }

            dgvAvalsPac.DataSource = dataTable;
            dgvAvalsPac.Columns[0].Visible = false;
            dgvAvalsPac.Columns[1].Visible = false;
            dgvAvalsPac.AutoResizeColumns();
            if (dgvAvalsPac.RowCount > 0) dgvAvalsPac.Rows[0].Selected = true;
        }

        // TAB ESPECIALISTA
        public void LoadLstEsp()
        {
            lstEsp.DataSource = null;
            lstEsp.DataSource = LoadEsp();
            lstEsp.DisplayMember = "Nome";
            lstEsp.ValueMember = "id";
        }

        // TAB PACIENTE
        public void LoadEspAddPac()
        {
            cmbEspAddPac.DataSource = null;
            cmbEspAddPac.DataSource = LoadEsp();
            cmbEspAddPac.DisplayMember = "Nome";
            cmbEspAddPac.ValueMember = "id";
            cmbEspAddPac.SelectedIndex = -1;
        }
        public void LoadEspUpdPac()
        {
            cmbEspUpdPac.DataSource = null;
            cmbEspUpdPac.DataSource = LoadEsp();
            cmbEspUpdPac.DisplayMember = "Nome";
            cmbEspUpdPac.ValueMember = "id";
        }
        public void LoadCmbPacPac(int espId)
        {
            cmbPacPac.DataSource = null;
            cmbPacPac.DataSource = LoadPac(espId);
            cmbPacPac.DisplayMember = "Nome";
            cmbPacPac.ValueMember = "id";
            ResetCtrlsUpd();

        }
        public void ResetCtrlsAdd()
        {
            btnExecPac.Text = "Cadastrar";
            txtAddPac.Text = "";
            dtpAddPac.Value = DateTime.Now;
            rdAddSexoF.Checked = false;
            rdAddSexoM.Checked = false;
            LoadEspAddPac();
            cmbEspAddPac.Text = "";
            cmbEspAddPac.Focus();
        }
        public void ResetCtrlsUpd()
        {
            txtUpdPac.Text = "";
            dtpUpdPac.Value = DateTime.Now;
            rdUpdSexoF.Checked = false;
            rdUpdSexoM.Checked = false;
            cmbEspUpdPac.Focus();
        }
        public void LoadPacDetails(int idPac)
        {
            ResetCtrlsUpd();
            var pac = ctx.Pacientes.Find(idPac);
            txtUpdPac.Text = pac.Nome;
            dtpUpdPac.Value = pac.DtNasc;
            if (pac.Sexo.Equals("M"))
            { rdUpdSexoM.Checked = true; } else { rdUpdSexoF.Checked = true; };
            
        }

        public void LoadDgvDelPac()
        {
            dgvDelPac.DataSource = null;
            var data = LoadPacData();
            if (data == null) return;

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdPac", typeof(int));
            //dataTable.Columns.Add("Especialista", typeof(string));
            dataTable.Columns.Add("Criança", typeof(string));
            dataTable.Columns.Add("Sexo", typeof(string));
            dataTable.Columns.Add("DtNasc", typeof(string));

            DataRow row = null;
            
            foreach (var rowObj in data)
            {
                row = dataTable.NewRow();
                dataTable.Rows.Add(rowObj.IdPac,  rowObj.Pac, rowObj.Sexo, rowObj.Dt);
            }

            dgvDelPac.DataSource = dataTable;
            dgvDelPac.Columns[0].Visible = false;
            dgvDelPac.AutoResizeColumns();
            if (dgvDelPac.RowCount > 0) dgvDelPac.Rows[0].Selected = true;

        }

        // -------------------------------------------------------------

        public IList<Especialista> LoadEsp()
        {
            var espLst = ctx.Especialistas.OrderBy(x => x.Nome).ToList();
            return espLst;
        }
        public IList<Paciente> LoadPac(int idEsp)
        {
            var pacLst = ctx.Pacientes.Where(p => p.Especialista_id == idEsp).OrderBy(x => x.Nome).ToList();
            return pacLst;
        }
        public class AvalData
        {
            public string prova;
            public int idAval;

            public string dtIni;
            public string dtFim;
            public string st;
        }
        public IList<PacData> LoadPacData()
        {
            var es = ctx.Especialistas.ToList();
            var ps = ctx.Pacientes.ToList();

            var query = from e in es
                        join p in ps on e.id equals p.Especialista_id
                        orderby e.Nome, p.Nome
                        select new PacData()
                        {
                            IdPac = p.id,
                            Esp = e.Nome,
                            Pac = p.Nome,
                            Sexo = p.Sexo.ToString(),
                            Dt = p.DtNasc.ToShortDateString()
                        };
            
            return query.ToList();

        }
        public class PacData
        {
            public int IdPac;
            public string Esp;
            public string Pac;
            public string Sexo;
            public string Dt;
        }
        public IList<fullHist> LoadLstAval(int idPac)
        {
            var hists = ctx.Avaliacaos.Where(x => x.Aluno_id == idPac).ToList();
            var avals = ctx.Questionarios.ToList();

            var query = from h in hists
                        join a in avals on h.Prova_id equals a.id
                        select new fullHist
                        {
                            idAval = h.id,
                            idProva = a.id,
                            Prova = a.Prova,
                            DtIni = h.DtIni.ToString(),
                            DtIFim = h.DtFim.ToString(),
                            Status = h.Status
                        };

            return query.ToList();

        }
        public class fullHist
        {
            public int idAval { get; set; }
            public int idProva { get; set; }
            public string Prova { get; set; }
            public string DtIni { get; set; }
            public string DtIFim { get; set; }
            public string Status { get; set; }
        }

        public void AddPac(int idEsp, string nome, DateTime dt, string sexo)
        {
            if (MessageBox.Show("Confirmar cadastro de nova Criança", "Coruja Educação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { cmbEspAddPac.SelectedIndex = -1;
                return;
            };
            try
            {
                string sex = sexo;
                Paciente novoPac = new Paciente { Nome = nome, Especialista_id = idEsp, DtNasc = dt, Sexo = sex, DtCadastro = DateTime.Now };
                ctx.Pacientes.Add(novoPac);
                ctx.SaveChanges();
                MessageBox.Show("Criança cadastrada com sucesso", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEspAddPac.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message, "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void UpdatePac(int idEsp, int idPac, string nome, DateTime dt, string sexo)
        {
            if (MessageBox.Show("Confirmar alteração de dados", "Coruja Educação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                cmbEspUpdPac.SelectedIndex = -1;
                return;
            };
            try
            {
                string sex = sexo;
                Paciente pac = ctx.Pacientes.Find(idPac);
                pac.Nome = nome;
                pac.DtNasc = dt;
                pac.Sexo = sex;
                pac.Especialista_id = idEsp;
                ctx.SaveChanges();

                MessageBox.Show("Dados atualizados com sucesso", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEspUpdPac.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message, "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void RemovePac(int idPac)
        {
            if (MessageBox.Show("Confirmar exclusão de Criança", "Coruja Educação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                var pac = ctx.Pacientes.Find(idPac);
                ctx.Pacientes.Remove(pac);
                ctx.SaveChanges();

                MessageBox.Show("Registro removido com sucesso", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message, "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void AddEsp(string nome)
        {
            if (MessageBox.Show("Confirmar cadastro de especialista", "Coruja Educação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                Especialista novoEsp = new Especialista();
                novoEsp.Nome = nome;
                ctx.Especialistas.Add(novoEsp);
                ctx.SaveChanges();
                MessageBox.Show("Registro adicionado com sucesso", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message, "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void UpdEsp(int IdEsp, string nome)
        {
            if (MessageBox.Show("Confirmar atualização de dados", "Coruja Educação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                var esp = ctx.Especialistas.Find(IdEsp);
                esp.Nome = nome;
                var entry = ctx.Entry(esp);
                ctx.Especialistas.Attach(esp);
                entry.State = EntityState.Modified;
                ctx.SaveChanges();
                MessageBox.Show("Registro atualizado com sucesso", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message, "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void RemoveEsp(int IdEsp)
        {
            if (MessageBox.Show("Confirmar exclusão de especialista", "Coruja Educação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                //Pac
                var pacs = ctx.Pacientes.Where(x => x.Especialista_id == IdEsp);
                foreach (var item in pacs)
                {
                    ctx.Pacientes.Remove(item);
                }

                //Esp
                var esp = ctx.Especialistas.Find(IdEsp);
                ctx.Especialistas.Remove(esp);
                ctx.SaveChanges();
                MessageBox.Show("Registro removido com sucesso", "Coruja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message, "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public void StartRegisterAval(int idEsp, int idPac, int idAval)
        {
            try
            {
                var newHist = new Avaliacao { Aluno_id = idPac, Prova_id = idAval, DtIni = DateTime.Now, Status = "Iniciada" };
                ctx.Avaliacaos.Add(newHist);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message);
            }

        }
        public void UpdStatus(int idAval, string newStatus)
        {
            try
            {
                var aval = ctx.Avaliacaos.Find(idAval);
                aval.Status = newStatus;
                var entry = ctx.Entry(aval);
                ctx.Avaliacaos.Attach(aval);
                entry.State = EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro ocorreu durante o processo: " + ex.Message);
            }

        }

        #endregion

        #region IniciaAvaliacao

        public class VerificaPasta
        {
            public string[] Pasta(string path)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    MessageBox.Show("Isso é um arquivo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    return Directory.GetDirectories(path, "Ano*");
                }
                else
                {
                    MessageBox.Show("Não é um diretório Valido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
        }

        public void InitializeComponentAval()
        {
            string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CorujaEdu";
            ConfigurationManager.AppSettings.Set("diretorio", diretorio);

            string local = ConfigurationManager.AppSettings["diretorio"];
            VerificaPasta ehPasta = new VerificaPasta();
            string[] pastas = ehPasta.Pasta(local);

            foreach (string pasta in pastas)
            {
                string[] arquivos = Directory.GetFiles(pasta + "\\DbStorage\\", "DBQUEST*");
                foreach (string arquivo in arquivos)
                {
                    if (arquivo == pasta + "\\DbStorage\\DBQUEST")
                    {
                        cmbAval.Items.AddRange(new object[] { pasta.Replace(local + "\\", "") });
                    }
                }
            }

        }

        private void cmbAval_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Activate();
            string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CorujaEdu";
            string Provas = "";
            string DBQUESTS = "";
            if (cmbAval.SelectedItem.ToString().Split('-').Length == 1)
            {
                Provas = diretorio + "\\" + cmbAval.SelectedItem.ToString();
                DBQUESTS = "\\DBQUEST";
            }
            else
            {
                Provas = diretorio + "\\" + cmbAval.SelectedItem.ToString().Split('-')[0].Trim(' ');
                DBQUESTS = "\\DBQUEST" + cmbAval.SelectedItem.ToString().Split('-')[1];
            }
            ConfigurationManager.AppSettings.Set("diretorio", diretorio);
             ConfigurationManager.AppSettings.Set("dbquest", DBQUESTS);
        }

        private void btnIniAval_Click(object sender, EventArgs e)
        {
           
            if (cmbEspAval.Text.Trim().Equals(""))
            {
                MessageBox.Show("Selecionar Especialista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbPacAval.Text.Trim().Equals(""))
            {
                MessageBox.Show("Selecionar Criança", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (rdNewAval.Checked == true)
            {

                if (cmbAval.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Selecionar Avaliação", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                ////////////////////////////////////////////////////////
                int pacId = (int)cmbPacAval.SelectedValue;
                string pr = cmbAval.Text;
               
                var avs = ctx.Avaliacaos.Where(a => a.Aluno_id == pacId).ToList();
                var prs = ctx.Questionarios.ToList();
                var res = (from a in avs
                            join p in prs on a.Prova_id equals p.id
                            where p.Prova.Equals(pr)
                            select a.Status).FirstOrDefault();

                if (!String.IsNullOrEmpty(res))
                {
                    if (res.Equals("Iniciada"))
                    {
                        MessageBox.Show("A Criança já tem uma prova de " + pr + " iniciada e deve finalizá-la para iniciar uma nova", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                ////////////////////////////////////////////////////////


            }
            else
            {
                if (dgvAvalsPac.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecionar Avaliação na lista", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var st = dgvAvalsPac.SelectedRows[0].Cells[5].Value.ToString();
            
                if ( st.Equals("Finalizada"))
                {
                    MessageBox.Show("Avaliação já finalizada", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }

            ////////////////////////////////////////////////////////

            // +++++++++++++++++++++++++++++++++++++++++++++++
            string esp = cmbEspAval.Text;
            int idPac = (int)cmbPacAval.SelectedValue;
            string pac = cmbPacAval.Text;
            string idAval = "";
            string idTipoProva = "";
            string prova = "";

            byte isNew = 0;
            string projPath = ConfigurationManager.AppSettings["diretorio"];

            if (rdNewAval.Checked == true)
            {
                isNew = 1;
                idAval = "0";
                prova = cmbAval.Text;
                var  qs = ctx.Questionarios.ToList();
                var query = (from q in qs
                             where q.Prova.Equals(prova)
                             select q.id).FirstOrDefault();
                idTipoProva = query.ToString();                              
            }
            else
            {
// *******************************************************************************
                idAval = dgvAvalsPac.SelectedRows[0].Cells[0].Value.ToString();
                idTipoProva = dgvAvalsPac.SelectedRows[0].Cells[1].Value.ToString();
                prova = dgvAvalsPac.SelectedRows[0].Cells[2].Value.ToString();
            }

            
            var pacDetail = ctx.Pacientes.Find(idPac);
            var dtNasc = pacDetail.DtNasc.ToShortDateString();
            var d = pacDetail.DtNasc.Day.ToString("00");
            var m = pacDetail.DtNasc.Month.ToString("00");
            var y = pacDetail.DtNasc.Year.ToString();

            var sexo = pacDetail.Sexo.ToString();

            string avalFullPath = projPath + "\\" + prova;

            ConfigurationManager.AppSettings.Set("escolheu", "1");
            ConfigurationManager.AppSettings.Set("avalFullPath", avalFullPath);
            ConfigurationManager.AppSettings.Set("novaAval", isNew.ToString());
            ConfigurationManager.AppSettings.Set("nomeProva", prova);
            ConfigurationManager.AppSettings.Set("idAval", idAval);
            ConfigurationManager.AppSettings.Set("idTipoProva", idTipoProva);
            ConfigurationManager.AppSettings.Set("esp", esp);
            ConfigurationManager.AppSettings.Set("pac", pac);
            ConfigurationManager.AppSettings.Set("idPac", idPac.ToString());
            ConfigurationManager.AppSettings.Set("dt", dtNasc);
            ConfigurationManager.AppSettings.Set("sexo", sexo);

            ConfigurationManager.AppSettings.Set("d", d); ConfigurationManager.AppSettings.Set("m", m); ConfigurationManager.AppSettings.Set("y", y);


            Close();

        }

        
        private void cmbAval_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnIniAval.Enabled = true;
        }

        private void FormAdm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (ConfigurationManager.AppSettings["escolheu"] != "1")
                {
                    ConfigurationManager.AppSettings.Set("escolheu", "0");
                }
            }
        }

      
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //string diretorio = ConfigurationManager.AppSettings["diretorio"];
            //string Provas = ConfigurationManager.AppSettings["raiz"];
            //string DBQUESTS = ConfigurationManager.AppSettings["dbquest"];
            //string deleteFile = Provas + DBQUESTS;

            //btnIniAval.Enabled = false;

            //if (System.IO.File.Exists(deleteFile))
            //{
            //    try
            //    {

            //        System.IO.File.Delete(deleteFile);
            //        cmbAval.Items.Remove(cmbAval.SelectedItem.ToString());
            //        if (Directory.GetFiles(Provas + "\\", "DBQUEST*").Count() == 0)
            //        {
            //            System.IO.Directory.Delete(Provas, true);
            //        }
            //    }
            //    catch (System.IO.IOException ei)
            //    {
            //        Console.WriteLine(ei.Message);
            //    }
            //}
        }

        private void cmbAval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnIniAval.Enabled)
            {
                ConfigurationManager.AppSettings.Set("escolheu", "1");
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        #endregion

        #region Opcoes

        private void linkCanal_Click(object sender, EventArgs e)
        {
            linkCanal.LinkVisited = true;
            System.Diagnostics.Process.Start("http://canal.corujaedu.com.br");
        }

        private void UploadPdf()
        {
           
            try
            {
                string filename = "Tutorial_Avaliacao.pdf";
                System.Diagnostics.Process.Start(filename);
                        

            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao carregar arquivo", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void lblTutorial_Click(object sender, EventArgs e)
        {
            UploadPdf();
        }

        #endregion

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }


}
