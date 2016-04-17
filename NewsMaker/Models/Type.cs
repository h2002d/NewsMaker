using NewsMaker.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsMaker.Models
{
    public class Type
    {
        private int typeId;
        private string typeName;

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public static List<Type> GetType(int? id)
        {
            return TypeDAO.getTypes(id);
        }

        public bool SaveType()
        {
            return TypeDAO.saveType(this);
        }
    }
}