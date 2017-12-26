using System;

namespace SSQLParser
{
    public class Spm
    {
        static void Main(string[] args)
		{
            //For testing purpouses
            SSQL sql_query;

            try
            {
                sql_query = new SSQL("SELect useRS, victims FROM USERS");

                foreach (string s in sql_query.getTargets())
    				Console.WriteLine("Selecciono: " + s);

                foreach (string s in sql_query.getTables())
					Console.WriteLine("De la tabla: " + s);

				Console.WriteLine("Ordenado por: " + sql_query.getOrderingIndex());
            }
            catch (InvalidSQLException ex){
                Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
            catch (NullReferenceException ex){
                Console.WriteLine("Invalid SQL syntax");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

		}
    }
}
