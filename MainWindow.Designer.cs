
namespace SVN_Updater {
partial class MainWindow
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
        if ( disposing && ( components != null ) )
        {
            components.Dispose();
        }
        base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SVNFolderTextBox = new System.Windows.Forms.TextBox();
        this.BrowseButton = new System.Windows.Forms.Button();
        this.FoldersListView = new System.Windows.Forms.ListView();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.UpdateButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // SVNFolderTextBox
        //
        this.SVNFolderTextBox.Location = new System.Drawing.Point( 12, 25 );
        this.SVNFolderTextBox.Name = "SVNFolderTextBox";
        this.SVNFolderTextBox.Size = new System.Drawing.Size( 156, 20 );
        this.SVNFolderTextBox.TabIndex = 0;
        this.SVNFolderTextBox.TextChanged += new System.EventHandler( this.SVNFolderTextBox_TextChanged );
        //
        // BrowseButton
        //
        this.BrowseButton.Location = new System.Drawing.Point( 174, 23 );
        this.BrowseButton.Name = "BrowseButton";
        this.BrowseButton.Size = new System.Drawing.Size( 75, 23 );
        this.BrowseButton.TabIndex = 1;
        this.BrowseButton.Text = "Browse";
        this.BrowseButton.UseVisualStyleBackColor = true;
        this.BrowseButton.Click += new System.EventHandler( this.BrowseButton_Click );
        //
        // FoldersListView
        //
        this.FoldersListView.HideSelection = false;
        this.FoldersListView.Location = new System.Drawing.Point( 12, 64 );
        this.FoldersListView.Name = "FoldersListView";
        this.FoldersListView.Size = new System.Drawing.Size( 237, 177 );
        this.FoldersListView.TabIndex = 2;
        this.FoldersListView.UseCompatibleStateImageBehavior = false;
        this.FoldersListView.View = System.Windows.Forms.View.List;
        this.FoldersListView.SelectedIndexChanged += new System.EventHandler( this.FoldersListView_SelectedIndexChanged );
        //
        // label1
        //
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point( 12, 9 );
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size( 64, 13 );
        this.label1.TabIndex = 3;
        this.label1.Text = "SVN Folder:";
        //
        // label2
        //
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point( 12, 48 );
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size( 112, 13 );
        this.label2.TabIndex = 4;
        this.label2.Text = "Available SVN folders:";
        //
        // UpdateButton
        //
        this.UpdateButton.Location = new System.Drawing.Point( 93, 247 );
        this.UpdateButton.Name = "UpdateButton";
        this.UpdateButton.Size = new System.Drawing.Size( 75, 23 );
        this.UpdateButton.TabIndex = 5;
        this.UpdateButton.Text = "Update";
        this.UpdateButton.UseVisualStyleBackColor = true;
        this.UpdateButton.Click += new System.EventHandler( this.UpdateButton_Click );
        //
        // MainWindow
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size( 260, 277 );
        this.Controls.Add( this.UpdateButton );
        this.Controls.Add( this.label2 );
        this.Controls.Add( this.label1 );
        this.Controls.Add( this.FoldersListView );
        this.Controls.Add( this.BrowseButton );
        this.Controls.Add( this.SVNFolderTextBox );
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Name = "MainWindow";
        this.Text = "SVN Updater";
        this.ResumeLayout( false );
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox SVNFolderTextBox;
    private System.Windows.Forms.Button BrowseButton;
    private System.Windows.Forms.ListView FoldersListView;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button UpdateButton;
}
}

