using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_phone_book.Repository
{
    public interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactId);
        DataTable Search(string parameter);
        bool Insert(string name,string family,int age,string mobile,string email,string address);
        bool Update(int contactId,string Name,string family, int age, string mobile, string email, string address);
        bool Delete(int contactId);
        

    }
}
