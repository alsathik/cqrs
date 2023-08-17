namespace RepositoryDesignPattren.CommandQuery
{
  
        public class AddCustomerCommand
        {
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }

        }

        public class UpdateCustomerCommand
        {
            public int Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }
            public bool IsActive { get; set; }
        }

        public class DeleteCustomerCommand
        {
            public int Id { get; set; }
        }

        //Queries

        public class GetAllCustomersQuery
        {
        }

        public class GetCustomerByIdQuery
        {
            public int Id { get; set; }
        }

        public class CustomerQueryResult
        {
            public int Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }
        }

}
