namespace API.Dtos
{
    public class LibeyUserDto
    {
        public string DocumentNumber { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeDescription { get; set; }
        public string Name { get; set; }
        public string FathersLastName { get; set; }
        public string MothersLastName { get; set; }
        public string Address { get; set; }
        public string UbigeoDescription { get; set; }
        public string ProvinceDescription { get; set; }
        public string RegionDescription { get; set; }
        public string UbigeoCode { get; set; }
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
