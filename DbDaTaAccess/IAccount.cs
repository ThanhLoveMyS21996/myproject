using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDaTaAccess
{
    internal interface IAccount
    {
         Account GetAccountById(int IdAccount);
        Account Check_GetAccountByName(Account AccountInputTruyen);
    }
}
