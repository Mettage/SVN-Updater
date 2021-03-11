using System;
using System.IO;
using System.Windows.Forms;

namespace SVN_Updater {
public partial class MainWindow : Form
{
    static string currentDir = Environment.CurrentDirectory;
    static string setting = currentDir + "\\setting.ini";
    static string svnfolder = "";
    static bool svnfoldervalid = false;
    static string selfol = "";
    static string[] selfols = null;
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
        FoldersListView.Items.Clear();
        if ( svnfoldervalid )
        {
            string[] dirs = Directory.GetDirectories( svnfolder );
            foreach ( string dir in dirs )
            {
                if ( Directory.Exists( dir + "\\.svn" ) )
                {
                    FoldersListView.Items.Add( Path.GetFileName( dir ) );
                }
            }
        }
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

    }

    private void SVNFolderTextBox_TextChanged( object sender, EventArgs e )
    {
        svnfolder = SVNFolderTextBox.Text;
        Set();
        CheckPath();
        ListFolders();
    }

    public void FoldersListView_SelectedIndexChanged( object sender, EventArgs e )
    {
        selfol = FoldersListView.SelectedItems.ToString();
        //selfols = FoldersListView.Items.Add( selfol );



        MessageBox.Show( selfol );
        //selfols = foldersListView.SelectedItems.ToString();

    }
}
}
