using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Оформление_заказов.DTO;
using Оформление_заказов.Tool;

namespace Оформление_заказов.MySQL
{
    class SQLModel
    {
        private SQLModel() { }
        static SQLModel sqlModel;
        public static SQLModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SQLModel();
            return sqlModel;
        }
        internal List<Grams> SelectGrams()
        {
            var grams = new List<Grams>();
            var mySqlDB = MySqlDB.GetDB();
            string query = "SELECT * FROM `grams`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        grams.Add(new Grams
                        {
                            ID = dr.GetInt32("id_grams"),
                            Title = dr.GetString("title_grams"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return grams;
        }
        internal List<User> SelectUser()
        {
            var users = new List<User>();
            var mySqlDB = MySqlDB.GetDB();
            string query = "SELECT * FROM `user`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        users.Add(new User
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("firstname"),
                            LastName =dr.GetString("lastname"),
                            Nomer = dr.GetString("nomer")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return users;
        }
        public List<User> SelectUsers(int skip, int count)
        {
            var users = new List<User>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `user` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        users.Add(new User
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("firstname"),
                            LastName = dr.GetString("lastname"),
                            Nomer = dr.GetString("nomer")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return users;
        }

        public List<User> SelectAllUsers()
        {
            List<User> Auser = new List<User>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `user`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Auser.Add(new User
                        {
                            ID = dr.GetInt32("id"),
                            Name = dr.GetString("firstname"),
                            LastName = dr.GetString("lastname"),
                            Nomer = dr.GetString("nomer")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return Auser;
        }
        public List<Grams> SelectGram(int skip, int count)
        {
            var grams = new List<Grams>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `grams` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        grams.Add(new Grams
                        {
                            ID = dr.GetInt32("id_grams"),
                            Title = dr.GetString("title_grams"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return grams;
        }
        public List<Menu> SelectMenus(int skip, int count)
        {
            var menus = new List<Menu>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `menu` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        menus.Add(new Menu
                        {
                            ID = dr.GetInt32("id_menu"),
                            Title = dr.GetString("title"),
                            Price = dr.GetInt32("price"),
                            Description = dr.GetString("description"),
                            TypeID = dr.GetInt32("type_id_type")
                            
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return menus;
        }
        public List<Product> SelectProducts(int skip, int count)
        {
            var products = new List<Product>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `ingredients` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        products.Add(new Product
                        {
                            ID = dr.GetInt32("id_ingr"),
                            Title = dr.GetString("title_ingr"),
                            GramID = dr.GetInt32("grams_id_grams")


                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return products;
        }
        public List<Types> SelectTypes(int skip, int count)
        {
            var types = new List<Types>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `type` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        types.Add(new Types
                        {
                            ID = dr.GetInt32("id_type"),
                            Title = dr.GetString("title_type"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return types;
        }
        public List<Reg> SelectReg(int skip, int count)
        {
            var regs = new List<Reg>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `registration` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        regs.Add(new Reg
                        {
                            ID = dr.GetInt32("id_reg"),
                            Nomer = dr.GetString("number"),
                            Date = dr.GetDateTime("data"),
                            UserId = dr.GetInt32("user_id")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return regs;
        }
        public List<Reg> SelectRegs()
        {
            var regs = new List<Reg>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `registration`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        regs.Add(new Reg
                        {
                            ID = dr.GetInt32("id_reg"),
                            Nomer = dr.GetString("number"),
                            Date = dr.GetDateTime("data"),
                            UserId = dr.GetInt32("user_id")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return regs;
        }
        public List<Reg> SelectAllReg(int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            var regs = new List<Reg>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM registration r, user u WHERE r.user_id = u.id and data >= '{startDate.ToShortDateString()}' and data <= '{endDate.ToShortDateString()}'";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var r = new Reg
                        {
                            ID = dr.GetInt32("id_reg"),
                            Nomer = dr.GetString("number"),
                            Date = dr.GetDateTime("data"),
                            UserId = dr.GetInt32("user_id")
                        };
                        regs.Add(r);
                    }
                }
                mySqlDB.CloseConnection();
            }
            return regs;
        }
        internal List<Menu> SelectMenuType(Types selectType)
        {
            int id = selectType?.ID ?? 0;
            var menus = new List<Menu>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT m.title,m.price, t.title_type, m.description, m.type_id_type FROM menu m, type t WHERE t.id_type = m.type_id_type AND m.type_id_type = {1}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var j = new Menu
                        {
                            Title = dr.GetString("title"),
                            Price = dr.GetInt32("price"),
                            Description = dr.GetString("description"),
                            TypeID = dr.GetInt32("type_id_type")
                        };
                        j.Types = new Types()
                        {
                            Title = dr.GetString("title_type"),
                        };
                        menus.Add(j);
                    }
                }
                mySqlDB.CloseConnection();
            }
            return menus;
        }
            public List<Drinks> SelectDrink(int skip, int count)
        {
            var drinks = new List<Drinks>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `drinks` LIMIT {skip},{count}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        drinks.Add(new Drinks
                        {
                            ID = dr.GetInt32("id_drink"),
                            Title = dr.GetString("title_drink"),
                            Price = dr.GetInt32("price_drink")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return drinks;
        }
        public List<Types> SelectType()
        {
            var types = new List<Types>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `type`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        types.Add(new Types
                        {
                            ID = dr.GetInt32("id_type"),
                            Title = dr.GetString("title_type"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return types;
        }
        public List<Types> SelectAllType()
        {
            List<Types> Atype = new List<Types>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `type`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Atype.Add(new Types
                        {
                            ID = dr.GetInt32("id_type"),
                            Title = dr.GetString("title_type"),
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return Atype;
        }
        public List<Drinks> SelectDrink()
        {
            var drinks = new List<Drinks>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `drinks`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        drinks.Add(new Drinks
                        {
                            ID = dr.GetInt32("id_drink"),
                            Title = dr.GetString("title_drink"),
                            Price = dr.GetInt32("price_drink")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return drinks;
        }
        internal List<Product> SelectProducrAndGrams( )
        {
            var products = new List<Product>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM  ingredients p, grams g  WHERE p.grams_id_grams = g.id_grams ";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var p = new Product
                        {
                            ID = dr.GetInt32("id_ingr"),
                            Title = dr.GetString("title_ingr"),
                            GramID = dr.GetInt32("grams_id_grams")
                        };
                        p.Grams = new Grams
                        {
                            ID = dr.GetInt32("id_grams"),
                            Title = dr.GetString("title_grams"),
                        };
                        products.Add(p);
                    }
                }
                mySqlDB.CloseConnection();
            }

            return products;
        }
        internal List<Menu> SelectMenuAndType()
        {
            var menus = new List<Menu>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM  menu m, type t  WHERE m.type_id_type = t.id_type ";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var m = new Menu
                        {
                            ID = dr.GetInt32("id_menu"),
                            Title = dr.GetString("title"),
                            TypeID = dr.GetInt32("type_id_type"),
                            Price = dr.GetInt32("price"),
                            Description = dr.GetString("description"),
                        };
                        m.Types = new Types
                        {
                            ID = dr.GetInt32("id_type"),
                            Title = dr.GetString("title_type"),
                        };
                        menus.Add(m);
                    }
                }
                mySqlDB.CloseConnection();
            }

            return menus;
        }

        public int Insert<T>(T value)
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateInsertQuery(table, values);
            var db = MySqlDB.GetDB();
            int id = db.GetNextID(table);
            db.ExecuteNonQuery(query.Item1, query.Item2);
            return id;
        }
        public void Update<T>(T value) where T : BaseDTO
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateUpdateQuery(table, values, value.ID);
            var db = MySqlDB.GetDB();
            db.ExecuteNonQuery(query.Item1, query.Item2);
        }

        public void Delete<T>(T value) where T : BaseDTO
        {
            var type = value.GetType();
            string table = GetTableName(type);
            var db = MySqlDB.GetDB();
            string query = $"delete from `{table}` where id = {value.ID}";
            db.ExecuteNonQuery(query);
        }

        public int GetNumRows(Type type)
        {
            string table = GetTableName(type);
            return MySqlDB.GetDB().GetRowsCount(table);
        }

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(tAttribute), false);
            return ((tAttribute)tableAtrributes.First()).Table;
        }
        private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<(string, object)> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"INSERT INTO `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<(string, object)> values, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            stringBuilder.Append($" WHERE id = {id}");
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static List<MySqlParameter> InitParameters(List<(string, object)> values, StringBuilder stringBuilder)
        {
            var parameters = new List<MySqlParameter>();
            int count = 1;
            var rows = values.Select(s =>
            {
                parameters.Add(new MySqlParameter($"p{count}", s.Item2));
                return $"{s.Item1} = @p{count++}";
            });
            stringBuilder.Append(string.Join(',', rows));
            return parameters;
        }

        private static void GetMetaData<T>(T value, out string table, out List<(string, object)> values)
        {
            var type = value.GetType();
            var tableAtrributes = type.GetCustomAttributes(typeof(tAttribute), false);
            table = ((tAttribute)tableAtrributes.First()).Table;
            values = new List<(string, object)>();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                var columnAttributes = prop.GetCustomAttributes(typeof(cAttribute), false);
                if (columnAttributes.Length > 0)
                {
                    string column = ((cAttribute)columnAttributes.First()).Column;
                    values.Add(new(column, prop.GetValue(value)));
                }
            }
        }
    }
}