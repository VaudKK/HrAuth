namespace HrAuth.Configurations{

    public class PostgreConfigurations{

        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public string ConnectionString { get{ 
            return $"Host={Host};Port={Port};Username={UserName};Password={Password};Database={Database};";
            } 
        }

    }

}