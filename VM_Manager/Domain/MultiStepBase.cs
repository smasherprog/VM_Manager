using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Domain
{
    public abstract class View_Model_To_Service
    {
        protected Dictionary<string, List<string>> _Validation_Errors;
        public Dictionary<string, List<string>> Errors { get { return new Dictionary<string, List<string>>(_Validation_Errors); } }
        public Libvirt.Models.Concrete.Validator Model_State;
        protected Libvirt.CS_Objects.Host _Connection;
        public Libvirt.CS_Objects.Host Connection { get { return _Connection; } }
        protected Libvirt.Models.Concrete.Virtual_Machine _Machine_Definition;
        public Libvirt.Models.Concrete.Virtual_Machine Machine_Definition { get { return _Machine_Definition; } }
     
        public View_Model_To_Service(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
        {
            _Validation_Errors = new Dictionary<string, List<string>>();
            Model_State = new Libvirt.Models.Concrete.Validator(_Validation_Errors);
            _Connection = con;
            _Machine_Definition = d;

        }
        public bool Validate()
        {
            _Validation_Errors = new Dictionary<string, List<string>>();
            Model_State = new Libvirt.Models.Concrete.Validator(_Validation_Errors);
            return Validate(Model_State);
        }
        abstract protected bool Validate(Libvirt.Models.Interface.IValdiator v);
    }
}
