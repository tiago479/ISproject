namespace AppA
{
    partial class Form1
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
            this.applicationName = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.findById = new System.Windows.Forms.TextBox();
            this.showById = new System.Windows.Forms.TextBox();
            this.getAllApps = new System.Windows.Forms.Button();
            this.getAllAppsBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.getAllModules = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.moduleByIdGet = new System.Windows.Forms.TextBox();
            this.getAllMods = new System.Windows.Forms.TextBox();
            this.moduleId = new System.Windows.Forms.TextBox();
            this.moduleName = new System.Windows.Forms.TextBox();
            this.moduleOldName = new System.Windows.Forms.Label();
            this.ModuleNames = new System.Windows.Forms.Label();
            this.resType = new System.Windows.Forms.TextBox();
            this.applicationModule = new System.Windows.Forms.Label();
            this.textBoxApplicationModule = new System.Windows.Forms.TextBox();
            this.setApp = new System.Windows.Forms.Button();
            this.setAppName = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.deleteApp = new System.Windows.Forms.TextBox();
            this.setModule = new System.Windows.Forms.Button();
            this.DeleteModule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // applicationName
            // 
            this.applicationName.Location = new System.Drawing.Point(12, 31);
            this.applicationName.Name = "applicationName";
            this.applicationName.Size = new System.Drawing.Size(100, 22);
            this.applicationName.TabIndex = 0;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 59);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "btnFindById";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // findById
            // 
            this.findById.Location = new System.Drawing.Point(205, 3);
            this.findById.Name = "findById";
            this.findById.Size = new System.Drawing.Size(29, 22);
            this.findById.TabIndex = 4;
            // 
            // showById
            // 
            this.showById.Location = new System.Drawing.Point(131, 59);
            this.showById.Multiline = true;
            this.showById.Name = "showById";
            this.showById.Size = new System.Drawing.Size(196, 88);
            this.showById.TabIndex = 5;
            // 
            // getAllApps
            // 
            this.getAllApps.Location = new System.Drawing.Point(538, 12);
            this.getAllApps.Name = "getAllApps";
            this.getAllApps.Size = new System.Drawing.Size(75, 23);
            this.getAllApps.TabIndex = 6;
            this.getAllApps.Text = "getAllApps";
            this.getAllApps.UseVisualStyleBackColor = true;
            this.getAllApps.Click += new System.EventHandler(this.getAllApps_Click);
            // 
            // getAllAppsBox
            // 
            this.getAllAppsBox.Location = new System.Drawing.Point(538, 41);
            this.getAllAppsBox.Name = "getAllAppsBox";
            this.getAllAppsBox.Size = new System.Drawing.Size(250, 254);
            this.getAllAppsBox.TabIndex = 7;
            this.getAllAppsBox.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 51);
            this.button2.TabIndex = 8;
            this.button2.Text = "create Module";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(159, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "btnFindById";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // getAllModules
            // 
            this.getAllModules.Location = new System.Drawing.Point(334, 421);
            this.getAllModules.Name = "getAllModules";
            this.getAllModules.Size = new System.Drawing.Size(99, 33);
            this.getAllModules.TabIndex = 10;
            this.getAllModules.Text = "getAllModes";
            this.getAllModules.UseVisualStyleBackColor = true;
            this.getAllModules.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 273);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 11;
            // 
            // moduleByIdGet
            // 
            this.moduleByIdGet.Location = new System.Drawing.Point(151, 273);
            this.moduleByIdGet.Name = "moduleByIdGet";
            this.moduleByIdGet.Size = new System.Drawing.Size(83, 22);
            this.moduleByIdGet.TabIndex = 12;
            // 
            // getAllMods
            // 
            this.getAllMods.Location = new System.Drawing.Point(300, 261);
            this.getAllMods.Multiline = true;
            this.getAllMods.Name = "getAllMods";
            this.getAllMods.Size = new System.Drawing.Size(173, 154);
            this.getAllMods.TabIndex = 13;
            // 
            // moduleId
            // 
            this.moduleId.Location = new System.Drawing.Point(184, 216);
            this.moduleId.Name = "moduleId";
            this.moduleId.Size = new System.Drawing.Size(28, 22);
            this.moduleId.TabIndex = 14;
            // 
            // moduleName
            // 
            this.moduleName.Location = new System.Drawing.Point(648, 304);
            this.moduleName.Name = "moduleName";
            this.moduleName.Size = new System.Drawing.Size(100, 22);
            this.moduleName.TabIndex = 15;
            // 
            // moduleOldName
            // 
            this.moduleOldName.AutoSize = true;
            this.moduleOldName.Location = new System.Drawing.Point(535, 334);
            this.moduleOldName.Name = "moduleOldName";
            this.moduleOldName.Size = new System.Drawing.Size(110, 16);
            this.moduleOldName.TabIndex = 16;
            this.moduleOldName.Text = "moduleOldName";
            // 
            // ModuleNames
            // 
            this.ModuleNames.AutoSize = true;
            this.ModuleNames.Location = new System.Drawing.Point(535, 310);
            this.ModuleNames.Name = "ModuleNames";
            this.ModuleNames.Size = new System.Drawing.Size(96, 16);
            this.ModuleNames.TabIndex = 17;
            this.ModuleNames.Text = "ModuleNames";
            // 
            // resType
            // 
            this.resType.Location = new System.Drawing.Point(647, 332);
            this.resType.Name = "resType";
            this.resType.Size = new System.Drawing.Size(101, 22);
            this.resType.TabIndex = 18;
            // 
            // applicationModule
            // 
            this.applicationModule.AutoSize = true;
            this.applicationModule.Location = new System.Drawing.Point(60, 179);
            this.applicationModule.Name = "applicationModule";
            this.applicationModule.Size = new System.Drawing.Size(161, 16);
            this.applicationModule.TabIndex = 19;
            this.applicationModule.Text = "application Module Name";
            // 
            // textBoxApplicationModule
            // 
            this.textBoxApplicationModule.Location = new System.Drawing.Point(227, 179);
            this.textBoxApplicationModule.Name = "textBoxApplicationModule";
            this.textBoxApplicationModule.Size = new System.Drawing.Size(112, 22);
            this.textBoxApplicationModule.TabIndex = 20;
            // 
            // setApp
            // 
            this.setApp.Location = new System.Drawing.Point(398, 68);
            this.setApp.Name = "setApp";
            this.setApp.Size = new System.Drawing.Size(75, 23);
            this.setApp.TabIndex = 21;
            this.setApp.Text = "setApp";
            this.setApp.UseVisualStyleBackColor = true;
            this.setApp.Click += new System.EventHandler(this.setApp_Click);
            // 
            // setAppName
            // 
            this.setAppName.Location = new System.Drawing.Point(387, 12);
            this.setAppName.Name = "setAppName";
            this.setAppName.Size = new System.Drawing.Size(108, 22);
            this.setAppName.TabIndex = 22;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(387, 40);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(96, 22);
            this.Name.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "oldNAme";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(393, 149);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 21);
            this.button4.TabIndex = 25;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // deleteApp
            // 
            this.deleteApp.Location = new System.Drawing.Point(393, 125);
            this.deleteApp.Name = "deleteApp";
            this.deleteApp.Size = new System.Drawing.Size(85, 22);
            this.deleteApp.TabIndex = 26;
            // 
            // setModule
            // 
            this.setModule.Location = new System.Drawing.Point(665, 360);
            this.setModule.Name = "setModule";
            this.setModule.Size = new System.Drawing.Size(123, 34);
            this.setModule.TabIndex = 27;
            this.setModule.Text = "setModule";
            this.setModule.UseVisualStyleBackColor = true;
            this.setModule.Click += new System.EventHandler(this.setModule_Click);
            // 
            // DeleteModule
            // 
            this.DeleteModule.Location = new System.Drawing.Point(538, 360);
            this.DeleteModule.Name = "DeleteModule";
            this.DeleteModule.Size = new System.Drawing.Size(121, 35);
            this.DeleteModule.TabIndex = 28;
            this.DeleteModule.Text = "DeleteModule";
            this.DeleteModule.UseVisualStyleBackColor = true;
            this.DeleteModule.Click += new System.EventHandler(this.DeleteModule_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteModule);
            this.Controls.Add(this.setModule);
            this.Controls.Add(this.deleteApp);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.setAppName);
            this.Controls.Add(this.setApp);
            this.Controls.Add(this.textBoxApplicationModule);
            this.Controls.Add(this.applicationModule);
            this.Controls.Add(this.resType);
            this.Controls.Add(this.ModuleNames);
            this.Controls.Add(this.moduleOldName);
            this.Controls.Add(this.moduleName);
            this.Controls.Add(this.moduleId);
            this.Controls.Add(this.getAllMods);
            this.Controls.Add(this.moduleByIdGet);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.getAllModules);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.getAllAppsBox);
            this.Controls.Add(this.getAllApps);
            this.Controls.Add(this.showById);
            this.Controls.Add(this.findById);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.applicationName);
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox applicationName;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox findById;
        private System.Windows.Forms.TextBox showById;
        private System.Windows.Forms.Button getAllApps;
        private System.Windows.Forms.RichTextBox getAllAppsBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button getAllModules;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox moduleByIdGet;
        private System.Windows.Forms.TextBox getAllMods;
        private System.Windows.Forms.TextBox moduleId;
        private System.Windows.Forms.TextBox moduleName;
        private System.Windows.Forms.Label moduleOldName;
        private System.Windows.Forms.Label ModuleNames;
        private System.Windows.Forms.TextBox resType;
        private System.Windows.Forms.Label applicationModule;
        private System.Windows.Forms.TextBox textBoxApplicationModule;
        private System.Windows.Forms.Button setApp;
        private System.Windows.Forms.TextBox setAppName;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox deleteApp;
        private System.Windows.Forms.Button setModule;
        private System.Windows.Forms.Button DeleteModule;
    }
}

