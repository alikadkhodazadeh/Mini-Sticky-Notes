namespace BookStore.Domain.Enums
{
    public enum RoleType
    {
        [Display(Name = "Super Admin")]
        SuperAdmin,

        [Display(Name = "Admin")]
        Admin,

        [Display(Name = "Author")]
        Author,

        [Display(Name = "Translator")]
        Translator,

        [Display(Name = "Customer")]
        Customer
    }
}
