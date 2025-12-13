namespace Cafeteria_Managment_System {
    public static class CurrentUser {
        public static int Userid { get; set; } 
        public static string Name = "";
        private static string _gender;
        public static string Gender { 
            set => _gender = (value == "male") ? "Mr." : "Mrs."; 
            get => _gender; 
        }
    }
}
