using System;
using System.Collections.Generic;
using System.Text;

namespace IP_BusinessLayer
{
    public class OvertimeUserCreator
    {
        private IOvertimeManager _overtimeManager;
        private IUserManager _userManager;

        public OvertimeUserCreator(IUserManager um, IOvertimeManager otm)
        {
            if(um == null)
            {
                throw new ArgumentException();
            }
            _userManager = um;
            if(otm == null)
            {
                throw new ArgumentException();
            }
            _overtimeManager = otm;
        }
    }
}
