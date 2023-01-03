namespace MaltApp
{
    partial class SOMIOD
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
            this.btnGetAllApp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearAppSelection = new System.Windows.Forms.Button();
            this.btnDeleteApp = new System.Windows.Forms.Button();
            this.dataGridViewApp = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_At = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupCreateNewApplication = new System.Windows.Forms.GroupBox();
            this.btnCreateApp = new System.Windows.Forms.Button();
            this.textNewAppName = new System.Windows.Forms.TextBox();
            this.groupGetApplicationById = new System.Windows.Forms.GroupBox();
            this.listShowById = new System.Windows.Forms.RichTextBox();
            this.btnGetAppById = new System.Windows.Forms.Button();
            this.textAppById = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateApp = new System.Windows.Forms.Button();
            this.textOldAppName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textAppName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearModuleSelection = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxApplicationModule = new System.Windows.Forms.TextBox();
            this.btnDeleteModule = new System.Windows.Forms.Button();
            this.dataGridViewModules = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGetAllModules = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCreateModule = new System.Windows.Forms.Button();
            this.textModuleName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.moduleDetail = new System.Windows.Forms.RichTextBox();
            this.btnFindModuleById = new System.Windows.Forms.Button();
            this.moduleId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnUpdateModule = new System.Windows.Forms.Button();
            this.textOldModuleName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textNewModuleName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.selectedModuleData = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textSelectedModule = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textDataContent = new System.Windows.Forms.TextBox();
            this.btnCreateData = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxEndpoint = new System.Windows.Forms.TextBox();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textSubName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCreateSub = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApp)).BeginInit();
            this.groupCreateNewApplication.SuspendLayout();
            this.groupGetApplicationById.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModules)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.selectedModuleData.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetAllApp
            // 
            this.btnGetAllApp.Location = new System.Drawing.Point(6, 19);
            this.btnGetAllApp.Name = "btnGetAllApp";
            this.btnGetAllApp.Size = new System.Drawing.Size(326, 28);
            this.btnGetAllApp.TabIndex = 0;
            this.btnGetAllApp.Text = "Get All Applications";
            this.btnGetAllApp.UseVisualStyleBackColor = true;
            this.btnGetAllApp.Click += new System.EventHandler(this.btnGetAllApp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearAppSelection);
            this.groupBox1.Controls.Add(this.btnDeleteApp);
            this.groupBox1.Controls.Add(this.dataGridViewApp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGetAllApp);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application";
            // 
            // btnClearAppSelection
            // 
            this.btnClearAppSelection.Enabled = false;
            this.btnClearAppSelection.Location = new System.Drawing.Point(139, 220);
            this.btnClearAppSelection.Name = "btnClearAppSelection";
            this.btnClearAppSelection.Size = new System.Drawing.Size(96, 23);
            this.btnClearAppSelection.TabIndex = 9;
            this.btnClearAppSelection.Text = "Clear selection";
            this.btnClearAppSelection.UseVisualStyleBackColor = true;
            this.btnClearAppSelection.Click += new System.EventHandler(this.btnClearAppSelection_Click);
            // 
            // btnDeleteApp
            // 
            this.btnDeleteApp.Enabled = false;
            this.btnDeleteApp.Location = new System.Drawing.Point(6, 220);
            this.btnDeleteApp.Name = "btnDeleteApp";
            this.btnDeleteApp.Size = new System.Drawing.Size(126, 23);
            this.btnDeleteApp.TabIndex = 8;
            this.btnDeleteApp.Text = "Delete Selected";
            this.btnDeleteApp.UseVisualStyleBackColor = true;
            this.btnDeleteApp.Click += new System.EventHandler(this.btnDeleteApp_Click);
            // 
            // dataGridViewApp
            // 
            this.dataGridViewApp.AllowUserToAddRows = false;
            this.dataGridViewApp.AllowUserToDeleteRows = false;
            this.dataGridViewApp.AllowUserToOrderColumns = true;
            this.dataGridViewApp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewApp.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.created_At});
            this.dataGridViewApp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewApp.Location = new System.Drawing.Point(6, 71);
            this.dataGridViewApp.MultiSelect = false;
            this.dataGridViewApp.Name = "dataGridViewApp";
            this.dataGridViewApp.ReadOnly = true;
            this.dataGridViewApp.RowHeadersVisible = false;
            this.dataGridViewApp.Size = new System.Drawing.Size(326, 143);
            this.dataGridViewApp.TabIndex = 7;
            this.dataGridViewApp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewApp_CellContentClick);
            this.dataGridViewApp.SelectionChanged += new System.EventHandler(this.dataGridViewApp_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // created_At
            // 
            this.created_At.HeaderText = "Created At";
            this.created_At.Name = "created_At";
            this.created_At.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available applications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupCreateNewApplication
            // 
            this.groupCreateNewApplication.Controls.Add(this.btnCreateApp);
            this.groupCreateNewApplication.Controls.Add(this.textNewAppName);
            this.groupCreateNewApplication.Controls.Add(this.label2);
            this.groupCreateNewApplication.Location = new System.Drawing.Point(12, 267);
            this.groupCreateNewApplication.Name = "groupCreateNewApplication";
            this.groupCreateNewApplication.Size = new System.Drawing.Size(338, 58);
            this.groupCreateNewApplication.TabIndex = 2;
            this.groupCreateNewApplication.TabStop = false;
            this.groupCreateNewApplication.Text = "Create new application";
            // 
            // btnCreateApp
            // 
            this.btnCreateApp.Location = new System.Drawing.Point(241, 22);
            this.btnCreateApp.Name = "btnCreateApp";
            this.btnCreateApp.Size = new System.Drawing.Size(91, 21);
            this.btnCreateApp.TabIndex = 5;
            this.btnCreateApp.Text = "Create";
            this.btnCreateApp.UseVisualStyleBackColor = true;
            this.btnCreateApp.Click += new System.EventHandler(this.btnCreateApp_Click);
            // 
            // textNewAppName
            // 
            this.textNewAppName.Location = new System.Drawing.Point(58, 23);
            this.textNewAppName.Name = "textNewAppName";
            this.textNewAppName.Size = new System.Drawing.Size(177, 20);
            this.textNewAppName.TabIndex = 4;
            this.textNewAppName.TextChanged += new System.EventHandler(this.textNewAppName_TextChanged);
            // 
            // groupGetApplicationById
            // 
            this.groupGetApplicationById.Controls.Add(this.listShowById);
            this.groupGetApplicationById.Controls.Add(this.btnGetAppById);
            this.groupGetApplicationById.Controls.Add(this.textAppById);
            this.groupGetApplicationById.Controls.Add(this.label3);
            this.groupGetApplicationById.Location = new System.Drawing.Point(12, 336);
            this.groupGetApplicationById.Name = "groupGetApplicationById";
            this.groupGetApplicationById.Size = new System.Drawing.Size(338, 107);
            this.groupGetApplicationById.TabIndex = 6;
            this.groupGetApplicationById.TabStop = false;
            this.groupGetApplicationById.Text = "Get Application by id";
            // 
            // listShowById
            // 
            this.listShowById.Location = new System.Drawing.Point(6, 49);
            this.listShowById.Name = "listShowById";
            this.listShowById.ReadOnly = true;
            this.listShowById.Size = new System.Drawing.Size(326, 52);
            this.listShowById.TabIndex = 7;
            this.listShowById.Text = "";
            // 
            // btnGetAppById
            // 
            this.btnGetAppById.Location = new System.Drawing.Point(241, 22);
            this.btnGetAppById.Name = "btnGetAppById";
            this.btnGetAppById.Size = new System.Drawing.Size(91, 21);
            this.btnGetAppById.TabIndex = 5;
            this.btnGetAppById.Text = "Find";
            this.btnGetAppById.UseVisualStyleBackColor = true;
            this.btnGetAppById.Click += new System.EventHandler(this.btnGetAppById_Click);
            // 
            // textAppById
            // 
            this.textAppById.Location = new System.Drawing.Point(58, 23);
            this.textAppById.Name = "textAppById";
            this.textAppById.Size = new System.Drawing.Size(177, 20);
            this.textAppById.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "App ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateApp);
            this.groupBox2.Controls.Add(this.textOldAppName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textAppName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 448);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 81);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update application";
            // 
            // btnUpdateApp
            // 
            this.btnUpdateApp.Location = new System.Drawing.Point(231, 23);
            this.btnUpdateApp.Name = "btnUpdateApp";
            this.btnUpdateApp.Size = new System.Drawing.Size(101, 47);
            this.btnUpdateApp.TabIndex = 5;
            this.btnUpdateApp.Text = "Update";
            this.btnUpdateApp.UseVisualStyleBackColor = true;
            this.btnUpdateApp.Click += new System.EventHandler(this.btnUpdateApp_Click);
            // 
            // textOldAppName
            // 
            this.textOldAppName.Location = new System.Drawing.Point(66, 23);
            this.textOldAppName.Name = "textOldAppName";
            this.textOldAppName.Size = new System.Drawing.Size(159, 20);
            this.textOldAppName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Old Name";
            // 
            // textAppName
            // 
            this.textAppName.Location = new System.Drawing.Point(66, 50);
            this.textAppName.Name = "textAppName";
            this.textAppName.Size = new System.Drawing.Size(159, 20);
            this.textAppName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "New Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearModuleSelection);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxApplicationModule);
            this.groupBox3.Controls.Add(this.btnDeleteModule);
            this.groupBox3.Controls.Add(this.dataGridViewModules);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnGetAllModules);
            this.groupBox3.Location = new System.Drawing.Point(369, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 280);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modules";
            // 
            // btnClearModuleSelection
            // 
            this.btnClearModuleSelection.Enabled = false;
            this.btnClearModuleSelection.Location = new System.Drawing.Point(177, 249);
            this.btnClearModuleSelection.Name = "btnClearModuleSelection";
            this.btnClearModuleSelection.Size = new System.Drawing.Size(96, 23);
            this.btnClearModuleSelection.TabIndex = 10;
            this.btnClearModuleSelection.Text = "Clear selection";
            this.btnClearModuleSelection.UseVisualStyleBackColor = true;
            this.btnClearModuleSelection.Click += new System.EventHandler(this.btnClearModuleSelection_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Selected App";
            // 
            // textBoxApplicationModule
            // 
            this.textBoxApplicationModule.Location = new System.Drawing.Point(79, 19);
            this.textBoxApplicationModule.Name = "textBoxApplicationModule";
            this.textBoxApplicationModule.Size = new System.Drawing.Size(253, 20);
            this.textBoxApplicationModule.TabIndex = 9;
            // 
            // btnDeleteModule
            // 
            this.btnDeleteModule.Enabled = false;
            this.btnDeleteModule.Location = new System.Drawing.Point(6, 249);
            this.btnDeleteModule.Name = "btnDeleteModule";
            this.btnDeleteModule.Size = new System.Drawing.Size(165, 23);
            this.btnDeleteModule.TabIndex = 8;
            this.btnDeleteModule.Text = "Delete Selected Module";
            this.btnDeleteModule.UseVisualStyleBackColor = true;
            this.btnDeleteModule.Click += new System.EventHandler(this.btnDeleteModule_Click);
            // 
            // dataGridViewModules
            // 
            this.dataGridViewModules.AllowUserToAddRows = false;
            this.dataGridViewModules.AllowUserToDeleteRows = false;
            this.dataGridViewModules.AllowUserToOrderColumns = true;
            this.dataGridViewModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewModules.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModules.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewModules.Location = new System.Drawing.Point(6, 100);
            this.dataGridViewModules.MultiSelect = false;
            this.dataGridViewModules.Name = "dataGridViewModules";
            this.dataGridViewModules.ReadOnly = true;
            this.dataGridViewModules.RowHeadersVisible = false;
            this.dataGridViewModules.Size = new System.Drawing.Size(326, 143);
            this.dataGridViewModules.TabIndex = 7;
            this.dataGridViewModules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModules_CellContentClick);
            this.dataGridViewModules.SelectionChanged += new System.EventHandler(this.dataGridViewModules_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Available Modules";
            // 
            // btnGetAllModules
            // 
            this.btnGetAllModules.Location = new System.Drawing.Point(6, 48);
            this.btnGetAllModules.Name = "btnGetAllModules";
            this.btnGetAllModules.Size = new System.Drawing.Size(326, 28);
            this.btnGetAllModules.TabIndex = 0;
            this.btnGetAllModules.Text = "Get All Application Modules";
            this.btnGetAllModules.UseVisualStyleBackColor = true;
            this.btnGetAllModules.Click += new System.EventHandler(this.btnGetAllModules_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreateModule);
            this.groupBox4.Controls.Add(this.textModuleName);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(369, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 58);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Create new module";
            // 
            // btnCreateModule
            // 
            this.btnCreateModule.Location = new System.Drawing.Point(241, 22);
            this.btnCreateModule.Name = "btnCreateModule";
            this.btnCreateModule.Size = new System.Drawing.Size(91, 21);
            this.btnCreateModule.TabIndex = 5;
            this.btnCreateModule.Text = "Create";
            this.btnCreateModule.UseVisualStyleBackColor = true;
            this.btnCreateModule.Click += new System.EventHandler(this.btnCreateModule_Click);
            // 
            // textModuleName
            // 
            this.textModuleName.Location = new System.Drawing.Point(58, 23);
            this.textModuleName.Name = "textModuleName";
            this.textModuleName.Size = new System.Drawing.Size(177, 20);
            this.textModuleName.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.moduleDetail);
            this.groupBox5.Controls.Add(this.btnFindModuleById);
            this.groupBox5.Controls.Add(this.moduleId);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(369, 362);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(338, 107);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Get Module by id";
            // 
            // moduleDetail
            // 
            this.moduleDetail.Location = new System.Drawing.Point(6, 49);
            this.moduleDetail.Name = "moduleDetail";
            this.moduleDetail.ReadOnly = true;
            this.moduleDetail.Size = new System.Drawing.Size(326, 52);
            this.moduleDetail.TabIndex = 7;
            this.moduleDetail.Text = "";
            // 
            // btnFindModuleById
            // 
            this.btnFindModuleById.Location = new System.Drawing.Point(241, 22);
            this.btnFindModuleById.Name = "btnFindModuleById";
            this.btnFindModuleById.Size = new System.Drawing.Size(91, 21);
            this.btnFindModuleById.TabIndex = 5;
            this.btnFindModuleById.Text = "Find";
            this.btnFindModuleById.UseVisualStyleBackColor = true;
            this.btnFindModuleById.Click += new System.EventHandler(this.btnFindModuleById_Click);
            // 
            // moduleId
            // 
            this.moduleId.Location = new System.Drawing.Point(68, 23);
            this.moduleId.Name = "moduleId";
            this.moduleId.Size = new System.Drawing.Size(167, 20);
            this.moduleId.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Module ID";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnUpdateModule);
            this.groupBox6.Controls.Add(this.textOldModuleName);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.textNewModuleName);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(369, 473);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(338, 81);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Update module";
            // 
            // btnUpdateModule
            // 
            this.btnUpdateModule.Location = new System.Drawing.Point(231, 23);
            this.btnUpdateModule.Name = "btnUpdateModule";
            this.btnUpdateModule.Size = new System.Drawing.Size(101, 47);
            this.btnUpdateModule.TabIndex = 5;
            this.btnUpdateModule.Text = "Update";
            this.btnUpdateModule.UseVisualStyleBackColor = true;
            this.btnUpdateModule.Click += new System.EventHandler(this.btnUpdateModule_Click);
            // 
            // textOldModuleName
            // 
            this.textOldModuleName.Location = new System.Drawing.Point(66, 23);
            this.textOldModuleName.Name = "textOldModuleName";
            this.textOldModuleName.Size = new System.Drawing.Size(159, 20);
            this.textOldModuleName.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Old Name";
            // 
            // textNewModuleName
            // 
            this.textNewModuleName.Location = new System.Drawing.Point(66, 50);
            this.textNewModuleName.Name = "textNewModuleName";
            this.textNewModuleName.Size = new System.Drawing.Size(159, 20);
            this.textNewModuleName.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "New Name";
            // 
            // selectedModuleData
            // 
            this.selectedModuleData.Controls.Add(this.label13);
            this.selectedModuleData.Controls.Add(this.textSelectedModule);
            this.selectedModuleData.Controls.Add(this.label12);
            this.selectedModuleData.Controls.Add(this.textDataContent);
            this.selectedModuleData.Controls.Add(this.btnCreateData);
            this.selectedModuleData.Location = new System.Drawing.Point(726, 12);
            this.selectedModuleData.Name = "selectedModuleData";
            this.selectedModuleData.Size = new System.Drawing.Size(338, 116);
            this.selectedModuleData.TabIndex = 9;
            this.selectedModuleData.TabStop = false;
            this.selectedModuleData.Text = "<Select Module>";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Module";
            // 
            // textSelectedModule
            // 
            this.textSelectedModule.Enabled = false;
            this.textSelectedModule.Location = new System.Drawing.Point(56, 24);
            this.textSelectedModule.Name = "textSelectedModule";
            this.textSelectedModule.ReadOnly = true;
            this.textSelectedModule.Size = new System.Drawing.Size(276, 20);
            this.textSelectedModule.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Content";
            // 
            // textDataContent
            // 
            this.textDataContent.Enabled = false;
            this.textDataContent.Location = new System.Drawing.Point(56, 47);
            this.textDataContent.Name = "textDataContent";
            this.textDataContent.Size = new System.Drawing.Size(276, 20);
            this.textDataContent.TabIndex = 9;
            // 
            // btnCreateData
            // 
            this.btnCreateData.Enabled = false;
            this.btnCreateData.Location = new System.Drawing.Point(6, 76);
            this.btnCreateData.Name = "btnCreateData";
            this.btnCreateData.Size = new System.Drawing.Size(326, 28);
            this.btnCreateData.TabIndex = 0;
            this.btnCreateData.Text = "Create";
            this.btnCreateData.UseVisualStyleBackColor = true;
            this.btnCreateData.Click += new System.EventHandler(this.btnCreateData_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnCreateSub);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.textSubName);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.textBoxEndpoint);
            this.groupBox7.Controls.Add(this.comboBoxEvent);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Location = new System.Drawing.Point(726, 134);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(338, 191);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Subscription";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 104);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "EndPoint";
            // 
            // textBoxEndpoint
            // 
            this.textBoxEndpoint.Location = new System.Drawing.Point(9, 119);
            this.textBoxEndpoint.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEndpoint.Name = "textBoxEndpoint";
            this.textBoxEndpoint.Size = new System.Drawing.Size(323, 20);
            this.textBoxEndpoint.TabIndex = 14;
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Items.AddRange(new object[] {
            "Creation",
            "Deletion"});
            this.comboBoxEvent.Location = new System.Drawing.Point(9, 79);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(323, 21);
            this.comboBoxEvent.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Event";
            // 
            // textSubName
            // 
            this.textSubName.Location = new System.Drawing.Point(9, 40);
            this.textSubName.Name = "textSubName";
            this.textSubName.Size = new System.Drawing.Size(323, 20);
            this.textSubName.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Name";
            // 
            // btnCreateSub
            // 
            this.btnCreateSub.Location = new System.Drawing.Point(9, 155);
            this.btnCreateSub.Name = "btnCreateSub";
            this.btnCreateSub.Size = new System.Drawing.Size(323, 28);
            this.btnCreateSub.TabIndex = 11;
            this.btnCreateSub.Text = "Create Subscription";
            this.btnCreateSub.UseVisualStyleBackColor = true;
            this.btnCreateSub.Click += new System.EventHandler(this.btnCreateSub_Click);
            // 
            // SOMIOD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 561);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.selectedModuleData);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupGetApplicationById);
            this.Controls.Add(this.groupCreateNewApplication);
            this.Controls.Add(this.groupBox1);
            this.Name = "SOMIOD";
            this.Text = "SOMIOD";
            this.Load += new System.EventHandler(this.SOMIOD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApp)).EndInit();
            this.groupCreateNewApplication.ResumeLayout(false);
            this.groupCreateNewApplication.PerformLayout();
            this.groupGetApplicationById.ResumeLayout(false);
            this.groupGetApplicationById.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModules)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.selectedModuleData.ResumeLayout(false);
            this.selectedModuleData.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGetAllApp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupCreateNewApplication;
        private System.Windows.Forms.Button btnCreateApp;
        private System.Windows.Forms.TextBox textNewAppName;
        private System.Windows.Forms.GroupBox groupGetApplicationById;
        private System.Windows.Forms.Button btnGetAppById;
        private System.Windows.Forms.TextBox textAppById;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_At;
        private System.Windows.Forms.RichTextBox listShowById;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textOldAppName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAppName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateApp;
        private System.Windows.Forms.Button btnDeleteApp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxApplicationModule;
        private System.Windows.Forms.Button btnDeleteModule;
        private System.Windows.Forms.DataGridView dataGridViewModules;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGetAllModules;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCreateModule;
        private System.Windows.Forms.TextBox textModuleName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox moduleDetail;
        private System.Windows.Forms.Button btnFindModuleById;
        private System.Windows.Forms.TextBox moduleId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnUpdateModule;
        private System.Windows.Forms.TextBox textOldModuleName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textNewModuleName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox selectedModuleData;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textDataContent;
        private System.Windows.Forms.Button btnCreateData;
        private System.Windows.Forms.Button btnClearAppSelection;
        private System.Windows.Forms.Button btnClearModuleSelection;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textSelectedModule;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textSubName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxEndpoint;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCreateSub;
    }
}

