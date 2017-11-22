using System;
namespace SSQLParser
{
    public class SSQL
    {
        string[] _targets;
        string[] _tables;
        int _orderIndex;

        /* By the moment it only proccesses simple querys like: SELECT * FROM * ORDER BY num
         * Possible expansion with the proccess of WHERE; GROUP, HAVING particles 
         * and JOINS.
         * By default, if needed, this library take ORDER BY's value by 1
        */
        public SSQL(string query)
        {
            char[] delimiter = { ' ', ',' };
			string[] words = query.Split(delimiter);

            int pointer = 0;

            if(words[0] == "SELECT")
            {
				pointer = parseTarget(words, pointer);
                pointer = parseFrom(words, pointer);
                pointer = parseOrder(words, pointer);
			}
        }

        /*
         * If success it loads a string array intro _targets 
         * attribute and returns new value for pointer. 
         * If error returns -1
        */
        private int parseTarget(string[] words, int pointer)
        {
            int init_p = pointer;

            while(words[pointer] != "FROM")
            {
                int i = 0;

                _targets = new string[20];
                _targets[i] = words[pointer];

                pointer++;
                i++;
            }

            if (pointer == init_p)
                return -1;
            
            return pointer;
        }

		private int parseFrom(string[] words, int pointer)
        {
			int init_p = pointer;

            if(words[pointer] == "FROM")
            {
                pointer++;
				while (words[pointer] != "ORDER")
				{
					int i = 0;

					_tables = new string[20];
					_tables[i] = words[pointer];

					pointer++;
					i++;
				}
            }

			if (pointer == init_p)
				return -1;

			return pointer;
        }

		private int parseOrder(string[] words, int pointer)
        {
			int init_p = pointer;

            if (words[pointer] == "ORDER")
            {
                pointer += 2;

                if (!int.TryParse(words[pointer], out _orderIndex))
                    _orderIndex = 1;
            }

			if (pointer == init_p)
            {
                _orderIndex = 1;
				return -1;
			}

			return pointer;
        }
	}
}
