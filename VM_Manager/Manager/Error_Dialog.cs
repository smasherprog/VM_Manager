using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Manager.Manager
{
    public partial class Error_Dialog : Form
    {
        public Error_Dialog(Libvirt.virError virError)
        {
            InitializeComponent();
            label7.Text = virError.code.ToString();
            label8.Text = virError.domain.ToString();
            label9.Text = virError.level.ToString();
            label10.Text = virError.message;
            label11.Text = virError.str1;
            label12.Text = virError.str2;
            label14.Text = virError.str3;
        }
    }
}
