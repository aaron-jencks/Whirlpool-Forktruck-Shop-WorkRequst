using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRequestSystem.Classes
{
    public class FormCompletionEventArgs : EventArgs
    {
        #region Properties

        private object data;

        #endregion

        #region Accessor Methods

        public object Data { get => data; set => data = value; }

        #endregion

        #region Constructors

        public FormCompletionEventArgs(object data)
        {
            this.data = data;
        }

        #endregion
    }
}
