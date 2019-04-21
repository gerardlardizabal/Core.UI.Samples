using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Core.App.PermissionHandlers
{
    public enum Permissions
    {
        NotSet = 0, //error condition

        // DEFINITIONS
        // Group - Permission Group, this could be the module or the page 
        // Name - This is the name of the permission
        // Description - This is the details about the permission, please always make this very definitive
        // ---------
        // When defining a permission make sure that the permission is very definitive, also the key code should be easy to identify by
        // by using the first digit as a module key ie "0 stands for accounts module", followed by 5 digits
    
        [Display(GroupName = "UserAccounts", Name = "CreateUser", Description = "Allows to create a new user")]
        ColorRead = 0x000001,
    }
}
