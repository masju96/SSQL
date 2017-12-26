using System;
using System.Collections;

namespace SSQLParser
{
    public class SSQL
    {
        public ArrayList _targets;
        public ArrayList _tables;
        public int _orderIndex = 1;
        private int _length;

        public ArrayList getTargets(){
            return this._targets;
        }

        public ArrayList getTables(){
			return this._tables;
		}

        public int getOrderingIndex(){
            return this._orderIndex;
        }

        /* By the moment, it only proccesses simple querys such as: SELECT * FROM * ORDER BY num
         * Possible expansion with the proccess of WHERE; GROUP, HAVING particles 
         * and JOINS.
         * By default, if needed, this library take ORDER BY's value by 1
        */
        public SSQL(string query)
        {
            char[] delimiter = { ' ', ',' };
            string[] words = query.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            this._length = words.Length;
            int pointer = 0;

            if(words[0].ToUpper().Equals("SELECT")){
                pointer++;
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
			int i = 0;

            _targets = new ArrayList();

			try{
                while (!words[pointer].ToUpper().Equals("FROM")){
                    _targets.Add(words[pointer]);
					pointer++;
					i++;
				}
			}
			catch (IndexOutOfRangeException){
				throw new InvalidSQLException("Invalid SQL query or non-supported structure.");
			}

            if (pointer == init_p)
                return -1;
            
            return pointer;
        }

		private int parseFrom(string[] words, int pointer)
        {
			int init_p = pointer;

            try{
                if (words[pointer].ToUpper().Equals("FROM")){
                    pointer++;
                    int i = 0;
                    _tables = new ArrayList();

                    while (pointer < this._length && !words[pointer].ToUpper().Equals("ORDER")){

                        _tables.Add(words[pointer]);

                        pointer++;
                        i++;
                    }
                }
			}
			catch (IndexOutOfRangeException){
				throw new InvalidSQLException("Invalid SQL query or non-supported structure");
			}

			if (pointer == init_p)
				return -1;

			return pointer;
        }

		private int parseOrder(string[] words, int pointer)
        {
			try{
                if (words[pointer].ToUpper().Equals("ORDER")){
    					pointer += 2;
    					if (!int.TryParse(words[pointer], out _orderIndex))
    						_orderIndex = 1;
                }
			}
			catch (IndexOutOfRangeException){
			}

			return pointer;
        }
	}
}
