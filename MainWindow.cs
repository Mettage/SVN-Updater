using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace SVN_Updater {
public partial class MainWindow : Form
{
    static string currentDir = Environment.CurrentDirectory;
    static string setting = currentDir + "\\setting.ini";
    static string selected = currentDir + "\\selecteditems.txt";
    static string updating = currentDir + "\\updating.bat";
    static string svnfolder = "";
    static int selfolderc = 0;
    static string[] fols = new string[20];
    static bool svnfoldervalid = false;
    public MainWindow()
    {
        Initialize();
        InitializeComponent();
        CheckPath();
        ListFolders();
        SVNFolderTextBox.Text = svnfolder;
    }

    void Initialize()
    {
        if ( File.Exists( setting ) )
        {
            StreamReader sets = new StreamReader( setting );
            int lineNumber = 0;
            string line = sets.ReadLine();
            while ( line != null )
            {
                lineNumber++;
                line = sets.ReadLine();
                if ( lineNumber == 1 ) { svnfolder = line; }
            }
            sets.Close();
        }
        else
        {
            using ( FileStream fileS = new FileStream( setting, FileMode.Create ) ) { Set(); }
        }

        if ( File.Exists( selected ) )
        { Remove(); }
        else
        {
            using ( FileStream fileF = new FileStream( selected, FileMode.Create ) ) { }
        }
    }

    static void Set()
    {
        StreamWriter settings = new StreamWriter( "setting.ini" );
        settings.WriteLine( "*** SVN Updater settings ***" );
        settings.WriteLine( svnfolder );
        settings.Close();
    }

    void CheckPath()
    {
        if ( Directory.Exists( svnfolder ) ) { svnfoldervalid = true; }
        else { svnfoldervalid = false; }
        StatusValid();
    }

    void StatusValid()
    {
        if ( svnfoldervalid )
        {
            UpdateButton.Enabled = true;
        }
        else
        {
            UpdateButton.Enabled = false;
        }
    }

    void ListFolders()
    {
        FoldersListBox.Items.Clear();
        if ( svnfoldervalid )
        {
            string[] dirs = Directory.GetDirectories( svnfolder );
            foreach ( string dir in dirs )
            {
                if ( Directory.Exists( dir + "\\.svn" ) )
                {
                    FoldersListBox.Items.Add( Path.GetFileName( dir ) );
                }
            }
        }
    }

    void Remove()
    {
        if ( File.Exists( selected ) )
        { File.Delete( selected ); }
        if ( File.Exists( updating ) )
        { File.Delete( updating ); }
    }

    void SelItems()
    {
        StreamWriter selFolder = new StreamWriter( selected );
        foreach ( var item in FoldersListBox.SelectedItems )
        {
            selFolder.WriteLine( item );
        }
        selFolder.Close();
    }

    private void BrowseButton_Click( object sender, EventArgs e )
    {
        FolderBrowserDialog SVNFolder = new FolderBrowserDialog();
        SVNFolder.SelectedPath = svnfolder;
        SVNFolder.Description = "Choose a folder where are stored SVN repositories";
        if ( SVNFolder.ShowDialog() == DialogResult.OK )
        {
            SVNFolderTextBox.Text = SVNFolder.SelectedPath;
            svnfolder = SVNFolder.SelectedPath;
            Set();
        }
    }

    public void UpdateButton_Click( object sender, EventArgs e )
    {
        SelItems();
        selfolderc = FoldersListBox.SelectedItems.Count;
        string discletter = svnfolder.Substring( 0, 1 );
        using ( StreamReader folders = new StreamReader( selected ) )
        {
            string line = folders.ReadLine();
            int j = 0;
            while ( line != null )
            {
                fols[j] = line;
                line = folders.ReadLine();
                j++;
            }
            folders.Close();
        }
        using ( StreamWriter command = new StreamWriter( updating ) )
        {
            command.WriteLine( $"@echo off" );
            command.WriteLine( discletter + $":" );
            command.WriteLine( $"cd " + svnfolder );
            for ( int i = 0; i < selfolderc; i++ )
            {
                command.WriteLine( $"svn cleanup " + fols[i] );
                command.WriteLine( $"svn update " + fols[i] );
            }
            //command.WriteLine( $"pause" );
            command.Close();
        }
        Process upd = new Process();
        upd.StartInfo.FileName = updating;
        upd.Start();
        UpdateButton.Enabled = false;
        BrowseButton.Enabled = false;
        upd.WaitForExit();
        UpdateButton.Enabled = true;
        BrowseButton.Enabled = true;
    }

    private void SVNFolderTextBox_TextChanged( object sender, EventArgs e )
    {
        svnfolder = SVNFolderTextBox.Text;
        Set();
        CheckPath();
        ListFolders();
    }

    private void MainWindow_FormClosing( object sender, FormClosingEventArgs e )
    {
        Remove();
    }
}
}
