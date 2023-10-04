using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic
{
    public class OperationManager
    {
        private static OperationManager _instance;
        private OperationManager()
        {

        }

        public static OperationManager Instance
        {
           get
            {
                if (_instance == null)
                {
                    _instance = new OperationManager();
                }

                return _instance;
            }
        }

        public OperationResult ExecuteOperation(Operation operation)
        {
            try
            {
                return operation.Execute();
            }
            catch(SqlException e)
            {
                //logger.LogError(e);
                return new OperationResult
                {
                    Errors = new List<string>
                    {
                        "Došlo je do greske u radu sa bazom podataka, pokusajte kasnije."
                    }
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Errors = new List<string>
                    {
                        "Došlo je do greške u sistemu, obratite se administratoru."
                    }
                };
            }
        }
    }
}
