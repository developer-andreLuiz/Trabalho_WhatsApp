
namespace Trabalho_WhatsApp.View
{
    partial class FrmResposta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timerInterface = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblContatosBloqueados = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMensagensRecebidas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAparelhosHabilitados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtMensagemInformacao = new System.Windows.Forms.TextBox();
            this.txtMensagemSair = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblEvento = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblAparelhoId = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnIniciarRespostas = new System.Windows.Forms.Button();
            this.btnEncerrarRespostas = new System.Windows.Forms.Button();
            this.nUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.timerEvento = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 46);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resposta";
            // 
            // timerInterface
            // 
            this.timerInterface.Enabled = true;
            this.timerInterface.Interval = 1000;
            this.timerInterface.Tick += new System.EventHandler(this.timerInterface_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(455, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(91, 22);
            this.panel2.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Informações";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblStatus);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.lblContatosBloqueados);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.lblMensagensRecebidas);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.lblAparelhosHabilitados);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(455, 124);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(264, 169);
            this.panel5.TabIndex = 63;
            // 
            // lblContatosBloqueados
            // 
            this.lblContatosBloqueados.AutoSize = true;
            this.lblContatosBloqueados.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatosBloqueados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.lblContatosBloqueados.Location = new System.Drawing.Point(204, 102);
            this.lblContatosBloqueados.Name = "lblContatosBloqueados";
            this.lblContatosBloqueados.Size = new System.Drawing.Size(17, 19);
            this.lblContatosBloqueados.TabIndex = 27;
            this.lblContatosBloqueados.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label8.Location = new System.Drawing.Point(3, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 19);
            this.label8.TabIndex = 26;
            this.label8.Text = "Contatos Bloqueados :";
            // 
            // lblMensagensRecebidas
            // 
            this.lblMensagensRecebidas.AutoSize = true;
            this.lblMensagensRecebidas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagensRecebidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.lblMensagensRecebidas.Location = new System.Drawing.Point(205, 53);
            this.lblMensagensRecebidas.Name = "lblMensagensRecebidas";
            this.lblMensagensRecebidas.Size = new System.Drawing.Size(17, 19);
            this.lblMensagensRecebidas.TabIndex = 25;
            this.lblMensagensRecebidas.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label6.Location = new System.Drawing.Point(4, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 19);
            this.label6.TabIndex = 24;
            this.label6.Text = "Mensagens Recebidas :";
            // 
            // lblAparelhosHabilitados
            // 
            this.lblAparelhosHabilitados.AutoSize = true;
            this.lblAparelhosHabilitados.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAparelhosHabilitados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.lblAparelhosHabilitados.Location = new System.Drawing.Point(204, 9);
            this.lblAparelhosHabilitados.Name = "lblAparelhosHabilitados";
            this.lblAparelhosHabilitados.Size = new System.Drawing.Size(17, 19);
            this.lblAparelhosHabilitados.TabIndex = 23;
            this.lblAparelhosHabilitados.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Aparelhos Habilitados :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(18, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(73, 22);
            this.panel3.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(2, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Resposta";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSalvar);
            this.panel4.Controls.Add(this.txtMensagemInformacao);
            this.panel4.Controls.Add(this.txtMensagemSair);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(18, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(425, 357);
            this.panel4.TabIndex = 65;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(69)))), ((int)(((byte)(98)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(20, 315);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(117, 29);
            this.btnSalvar.TabIndex = 81;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtMensagemInformacao
            // 
            this.txtMensagemInformacao.BackColor = System.Drawing.Color.White;
            this.txtMensagemInformacao.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensagemInformacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.txtMensagemInformacao.Location = new System.Drawing.Point(20, 195);
            this.txtMensagemInformacao.MaxLength = 255;
            this.txtMensagemInformacao.Multiline = true;
            this.txtMensagemInformacao.Name = "txtMensagemInformacao";
            this.txtMensagemInformacao.Size = new System.Drawing.Size(378, 111);
            this.txtMensagemInformacao.TabIndex = 26;
            this.txtMensagemInformacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMensagemSair
            // 
            this.txtMensagemSair.BackColor = System.Drawing.Color.White;
            this.txtMensagemSair.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensagemSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.txtMensagemSair.Location = new System.Drawing.Point(20, 39);
            this.txtMensagemSair.MaxLength = 255;
            this.txtMensagemSair.Multiline = true;
            this.txtMensagemSair.Name = "txtMensagemSair";
            this.txtMensagemSair.Size = new System.Drawing.Size(378, 111);
            this.txtMensagemSair.TabIndex = 25;
            this.txtMensagemSair.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label11.Location = new System.Drawing.Point(16, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(184, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "Mensagem de Informação";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label10.Location = new System.Drawing.Point(16, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "Mensagem de Sair";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(455, 308);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 22);
            this.panel6.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(2, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 19);
            this.label12.TabIndex = 15;
            this.label12.Text = "Último Evento";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblTelefone);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.lblEvento);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.lblAparelhoId);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Location = new System.Drawing.Point(455, 336);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(264, 145);
            this.panel7.TabIndex = 67;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefone.ForeColor = System.Drawing.Color.Maroon;
            this.lblTelefone.Location = new System.Drawing.Point(152, 107);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(97, 19);
            this.lblTelefone.TabIndex = 32;
            this.lblTelefone.Text = "21912345678";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label16.Location = new System.Drawing.Point(37, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 19);
            this.label16.TabIndex = 31;
            this.label16.Text = "Telefone  :";
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvento.ForeColor = System.Drawing.Color.Maroon;
            this.lblEvento.Location = new System.Drawing.Point(164, 62);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(85, 19);
            this.lblEvento.TabIndex = 30;
            this.lblEvento.Text = "Informação";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label15.Location = new System.Drawing.Point(48, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 19);
            this.label15.TabIndex = 29;
            this.label15.Text = "Evento  :";
            // 
            // lblAparelhoId
            // 
            this.lblAparelhoId.AutoSize = true;
            this.lblAparelhoId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAparelhoId.ForeColor = System.Drawing.Color.Maroon;
            this.lblAparelhoId.Location = new System.Drawing.Point(204, 21);
            this.lblAparelhoId.Name = "lblAparelhoId";
            this.lblAparelhoId.Size = new System.Drawing.Size(17, 19);
            this.lblAparelhoId.TabIndex = 28;
            this.lblAparelhoId.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label18.Location = new System.Drawing.Point(3, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 19);
            this.label18.TabIndex = 22;
            this.label18.Text = "Aparelho Id nº :";
            // 
            // btnIniciarRespostas
            // 
            this.btnIniciarRespostas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnIniciarRespostas.FlatAppearance.BorderSize = 0;
            this.btnIniciarRespostas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.btnIniciarRespostas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(69)))), ((int)(((byte)(98)))));
            this.btnIniciarRespostas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarRespostas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarRespostas.ForeColor = System.Drawing.Color.White;
            this.btnIniciarRespostas.Location = new System.Drawing.Point(18, 507);
            this.btnIniciarRespostas.Name = "btnIniciarRespostas";
            this.btnIniciarRespostas.Size = new System.Drawing.Size(152, 60);
            this.btnIniciarRespostas.TabIndex = 70;
            this.btnIniciarRespostas.Text = "Iniciar Respostas";
            this.btnIniciarRespostas.UseVisualStyleBackColor = false;
            this.btnIniciarRespostas.Click += new System.EventHandler(this.btnIniciarRespostas_Click);
            // 
            // btnEncerrarRespostas
            // 
            this.btnEncerrarRespostas.BackColor = System.Drawing.Color.Maroon;
            this.btnEncerrarRespostas.FlatAppearance.BorderSize = 0;
            this.btnEncerrarRespostas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.btnEncerrarRespostas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(69)))), ((int)(((byte)(98)))));
            this.btnEncerrarRespostas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncerrarRespostas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncerrarRespostas.ForeColor = System.Drawing.Color.White;
            this.btnEncerrarRespostas.Location = new System.Drawing.Point(567, 507);
            this.btnEncerrarRespostas.Name = "btnEncerrarRespostas";
            this.btnEncerrarRespostas.Size = new System.Drawing.Size(152, 60);
            this.btnEncerrarRespostas.TabIndex = 71;
            this.btnEncerrarRespostas.Text = "Encerrar Respostas";
            this.btnEncerrarRespostas.UseVisualStyleBackColor = false;
            this.btnEncerrarRespostas.Click += new System.EventHandler(this.btnEncerrarRespostas_Click);
            // 
            // nUD
            // 
            this.nUD.BackColor = System.Drawing.Color.White;
            this.nUD.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUD.Location = new System.Drawing.Point(201, 516);
            this.nUD.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD.Name = "nUD";
            this.nUD.Size = new System.Drawing.Size(77, 41);
            this.nUD.TabIndex = 72;
            this.nUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nUD.ValueChanged += new System.EventHandler(this.nUD_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label3.Location = new System.Drawing.Point(284, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 57);
            this.label3.TabIndex = 28;
            this.label3.Text = "Intervalo da \r\nVerificação\r\nMinutos";
            // 
            // timerEvento
            // 
            this.timerEvento.Interval = 1000;
            this.timerEvento.Tick += new System.EventHandler(this.timerEvento_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label5.Location = new System.Drawing.Point(4, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "Status :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(80, 137);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 26);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "Livre";
            // 
            // FrmResposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(737, 595);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUD);
            this.Controls.Add(this.btnEncerrarRespostas);
            this.Controls.Add(this.btnIniciarRespostas);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmResposta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmResposta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmResposta_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerInterface;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblContatosBloqueados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMensagensRecebidas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAparelhosHabilitados;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblAparelhoId;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMensagemInformacao;
        private System.Windows.Forms.TextBox txtMensagemSair;
        private System.Windows.Forms.Button btnIniciarRespostas;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEncerrarRespostas;
        private System.Windows.Forms.NumericUpDown nUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerEvento;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
    }
}