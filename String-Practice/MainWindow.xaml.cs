using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace String_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            string stack = txtInput.Text;
            if (stack == "")
                return;

            const string Space = " ";
            var tokens = stack.Split(new string[] { Space }, StringSplitOptions.None).Select(token => token.Trim().ToLower());

            var dictionary = new Dictionary<string, int>();

            foreach(var token in tokens)
            {
                if(dictionary.ContainsKey(token))
                {
                    dictionary[token]++;
                }
                else
                {
                    dictionary[token] = 1;
                }
            }

            var screen = new Stats(dictionary);
            screen.ShowDialog();
        }

        private void btnNor_Click(object sender, RoutedEventArgs e)
        {
            var fullname = txtInput.Text;
            if (fullname == "")
                return;
            const string Space = " ";
            var tokens = fullname.Split(new string[] { Space },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(token =>
                {
                    token = token.Trim().ToLower();
                    var firstChar = token.Substring(0, 1).ToUpper();
                    var remaining = token.Substring(1, token.Length - 1);
                    return firstChar + remaining;
                });

            var builder = new StringBuilder();
            foreach (var token in tokens)
            {
                builder.Append(token);
                builder.Append(Space);
            }

            builder.Remove(builder.Length - 1, 1);

            string normalize = builder.ToString();
            var screen = new Norm(normalize);
            screen.ShowDialog();

        }

        private void btnFPInfo_Click(object sender, RoutedEventArgs e)
        {
            var path = txtInput.Text;
            if (path == "" || !path.Contains(@"\"))
                return;
            const string BackSlash = @"\";
            const string Dot = ".";
            var foundPos = path.LastIndexOf(BackSlash);
            var directory = path.Substring(0, foundPos);
            var filename = path.Substring(foundPos + 1, path.Length - foundPos - 1);

            foundPos = path.LastIndexOf(Dot);
            var extension = path.Substring(foundPos + 1, path.Length - foundPos - 1);
            string pathInfo = directory + " - " + filename + " - " + extension;

            var screen = new Info(pathInfo);
            screen.ShowDialog();

        }
    }
}
