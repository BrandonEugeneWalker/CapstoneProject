﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capstone_Database.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OnlineEntities : DbContext
    {
        public OnlineEntities()
            : base("name=OnlineEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ItemRental> ItemRentals { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<ItemShip> ItemShips { get; set; }
        public virtual DbSet<ItemReturn> ItemReturns { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    
        public virtual int createMemberOrder(Nullable<int> selectedStockId, Nullable<int> selectedMemberId)
        {
            var selectedStockIdParameter = selectedStockId.HasValue ?
                new ObjectParameter("selectedStockId", selectedStockId) :
                new ObjectParameter("selectedStockId", typeof(int));
    
            var selectedMemberIdParameter = selectedMemberId.HasValue ?
                new ObjectParameter("selectedMemberId", selectedMemberId) :
                new ObjectParameter("selectedMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createMemberOrder", selectedStockIdParameter, selectedMemberIdParameter);
        }
    
        public virtual ObjectResult<retrieveAllProducts_Result> retrieveAllProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<retrieveAllProducts_Result>("retrieveAllProducts");
        }
    
        public virtual ObjectResult<Product> retrieveAvailableProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("retrieveAvailableProducts");
        }
    
        public virtual ObjectResult<Product> retrieveAvailableProducts(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("retrieveAvailableProducts", mergeOption);
        }
    
        public virtual ObjectResult<ItemRental> retrieveProductsWaitingReturn()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemRental>("retrieveProductsWaitingReturn");
        }
    
        public virtual ObjectResult<ItemRental> retrieveProductsWaitingReturn(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemRental>("retrieveProductsWaitingReturn", mergeOption);
        }
    
        public virtual ObjectResult<ItemRental> retrieveProductsWaitingShipment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemRental>("retrieveProductsWaitingShipment");
        }
    
        public virtual ObjectResult<ItemRental> retrieveProductsWaitingShipment(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemRental>("retrieveProductsWaitingShipment", mergeOption);
        }
    
        public virtual ObjectResult<Nullable<int>> retrieveRentedCount(Nullable<int> selectedMemberId)
        {
            var selectedMemberIdParameter = selectedMemberId.HasValue ?
                new ObjectParameter("selectedMemberId", selectedMemberId) :
                new ObjectParameter("selectedMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("retrieveRentedCount", selectedMemberIdParameter);
        }
    
        public virtual ObjectResult<Product> searchProductsName(string nameSearch)
        {
            var nameSearchParameter = nameSearch != null ?
                new ObjectParameter("nameSearch", nameSearch) :
                new ObjectParameter("nameSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("searchProductsName", nameSearchParameter);
        }
    
        public virtual ObjectResult<Product> searchProductsName(string nameSearch, MergeOption mergeOption)
        {
            var nameSearchParameter = nameSearch != null ?
                new ObjectParameter("nameSearch", nameSearch) :
                new ObjectParameter("nameSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("searchProductsName", mergeOption, nameSearchParameter);
        }
    
        public virtual ObjectResult<Product> searchProductsNameType(string nameSearch, string typeSearch)
        {
            var nameSearchParameter = nameSearch != null ?
                new ObjectParameter("nameSearch", nameSearch) :
                new ObjectParameter("nameSearch", typeof(string));
    
            var typeSearchParameter = typeSearch != null ?
                new ObjectParameter("typeSearch", typeSearch) :
                new ObjectParameter("typeSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("searchProductsNameType", nameSearchParameter, typeSearchParameter);
        }
    
        public virtual ObjectResult<Product> searchProductsNameType(string nameSearch, string typeSearch, MergeOption mergeOption)
        {
            var nameSearchParameter = nameSearch != null ?
                new ObjectParameter("nameSearch", nameSearch) :
                new ObjectParameter("nameSearch", typeof(string));
    
            var typeSearchParameter = typeSearch != null ?
                new ObjectParameter("typeSearch", typeSearch) :
                new ObjectParameter("typeSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("searchProductsNameType", mergeOption, nameSearchParameter, typeSearchParameter);
        }
    
        public virtual ObjectResult<Product> searchProductsType(string typeSearch)
        {
            var typeSearchParameter = typeSearch != null ?
                new ObjectParameter("typeSearch", typeSearch) :
                new ObjectParameter("typeSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("searchProductsType", typeSearchParameter);
        }
    
        public virtual ObjectResult<Product> searchProductsType(string typeSearch, MergeOption mergeOption)
        {
            var typeSearchParameter = typeSearch != null ?
                new ObjectParameter("typeSearch", typeSearch) :
                new ObjectParameter("typeSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("searchProductsType", mergeOption, typeSearchParameter);
        }
    
        public virtual int updateMemberReturn(Nullable<int> selectedRentalId)
        {
            var selectedRentalIdParameter = selectedRentalId.HasValue ?
                new ObjectParameter("selectedRentalId", selectedRentalId) :
                new ObjectParameter("selectedRentalId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateMemberReturn", selectedRentalIdParameter);
        }
    
        public virtual int updateRentalShipped(Nullable<int> selectedRentalId)
        {
            var selectedRentalIdParameter = selectedRentalId.HasValue ?
                new ObjectParameter("selectedRentalId", selectedRentalId) :
                new ObjectParameter("selectedRentalId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateRentalShipped", selectedRentalIdParameter);
        }
    
        public virtual int updateReturnProcessed(Nullable<int> selectedRentalId)
        {
            var selectedRentalIdParameter = selectedRentalId.HasValue ?
                new ObjectParameter("selectedRentalId", selectedRentalId) :
                new ObjectParameter("selectedRentalId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateReturnProcessed", selectedRentalIdParameter);
        }
    
        public virtual ObjectResult<Employee> selectEmployeeByIdAndPassword(Nullable<int> id, string pwd)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("selectEmployeeByIdAndPassword", idParameter, pwdParameter);
        }
    
        public virtual ObjectResult<Employee> selectEmployeeByIdAndPassword(Nullable<int> id, string pwd, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee>("selectEmployeeByIdAndPassword", mergeOption, idParameter, pwdParameter);
        }
    
        public virtual int insertEmployee(Nullable<int> id, string pw, Nullable<sbyte> isMan, string epName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var pwParameter = pw != null ?
                new ObjectParameter("pw", pw) :
                new ObjectParameter("pw", typeof(string));
    
            var isManParameter = isMan.HasValue ?
                new ObjectParameter("isMan", isMan) :
                new ObjectParameter("isMan", typeof(sbyte));
    
            var epNameParameter = epName != null ?
                new ObjectParameter("epName", epName) :
                new ObjectParameter("epName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertEmployee", idParameter, pwParameter, isManParameter, epNameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> findAvailableStockOfProduct(Nullable<int> selectedProductId)
        {
            var selectedProductIdParameter = selectedProductId.HasValue ?
                new ObjectParameter("selectedProductId", selectedProductId) :
                new ObjectParameter("selectedProductId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("findAvailableStockOfProduct", selectedProductIdParameter);
        }
    
        public virtual int insertMember(string newUsername, string newName, string newPassword, Nullable<sbyte> isLibrarian)
        {
            var newUsernameParameter = newUsername != null ?
                new ObjectParameter("newUsername", newUsername) :
                new ObjectParameter("newUsername", typeof(string));
    
            var newNameParameter = newName != null ?
                new ObjectParameter("newName", newName) :
                new ObjectParameter("newName", typeof(string));
    
            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("newPassword", newPassword) :
                new ObjectParameter("newPassword", typeof(string));
    
            var isLibrarianParameter = isLibrarian.HasValue ?
                new ObjectParameter("isLibrarian", isLibrarian) :
                new ObjectParameter("isLibrarian", typeof(sbyte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertMember", newUsernameParameter, newNameParameter, newPasswordParameter, isLibrarianParameter);
        }
    
        public virtual ObjectResult<Member> selectMemberByIdAndPassword(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Member>("selectMemberByIdAndPassword", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Member> selectMemberByIdAndPassword(string username, string password, MergeOption mergeOption)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Member>("selectMemberByIdAndPassword", mergeOption, usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Product> retrieveAvailableProductsWithSearch(string nameSearch, string typeSearch)
        {
            var nameSearchParameter = nameSearch != null ?
                new ObjectParameter("nameSearch", nameSearch) :
                new ObjectParameter("nameSearch", typeof(string));
    
            var typeSearchParameter = typeSearch != null ?
                new ObjectParameter("typeSearch", typeSearch) :
                new ObjectParameter("typeSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("retrieveAvailableProductsWithSearch", nameSearchParameter, typeSearchParameter);
        }
    
        public virtual ObjectResult<Product> retrieveAvailableProductsWithSearch(string nameSearch, string typeSearch, MergeOption mergeOption)
        {
            var nameSearchParameter = nameSearch != null ?
                new ObjectParameter("nameSearch", nameSearch) :
                new ObjectParameter("nameSearch", typeof(string));
    
            var typeSearchParameter = typeSearch != null ?
                new ObjectParameter("typeSearch", typeSearch) :
                new ObjectParameter("typeSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("retrieveAvailableProductsWithSearch", mergeOption, nameSearchParameter, typeSearchParameter);
        }
    
        public virtual int editMember(string newUsername, string newName, string newPassword, Nullable<int> currentMemberId)
        {
            var newUsernameParameter = newUsername != null ?
                new ObjectParameter("newUsername", newUsername) :
                new ObjectParameter("newUsername", typeof(string));
    
            var newNameParameter = newName != null ?
                new ObjectParameter("newName", newName) :
                new ObjectParameter("newName", typeof(string));
    
            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("newPassword", newPassword) :
                new ObjectParameter("newPassword", typeof(string));
    
            var currentMemberIdParameter = currentMemberId.HasValue ?
                new ObjectParameter("currentMemberId", currentMemberId) :
                new ObjectParameter("currentMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editMember", newUsernameParameter, newNameParameter, newPasswordParameter, currentMemberIdParameter);
        }
    
        public virtual ObjectResult<ItemRental> retrieveMembersRentals(Nullable<int> selectedMemberId)
        {
            var selectedMemberIdParameter = selectedMemberId.HasValue ?
                new ObjectParameter("selectedMemberId", selectedMemberId) :
                new ObjectParameter("selectedMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemRental>("retrieveMembersRentals", selectedMemberIdParameter);
        }
    
        public virtual ObjectResult<ItemRental> retrieveMembersRentals(Nullable<int> selectedMemberId, MergeOption mergeOption)
        {
            var selectedMemberIdParameter = selectedMemberId.HasValue ?
                new ObjectParameter("selectedMemberId", selectedMemberId) :
                new ObjectParameter("selectedMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemRental>("retrieveMembersRentals", mergeOption, selectedMemberIdParameter);
        }
    
        public virtual ObjectResult<Address> retrieveMembersAddresses(Nullable<int> selectedMemberId)
        {
            var selectedMemberIdParameter = selectedMemberId.HasValue ?
                new ObjectParameter("selectedMemberId", selectedMemberId) :
                new ObjectParameter("selectedMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Address>("retrieveMembersAddresses", selectedMemberIdParameter);
        }
    
        public virtual ObjectResult<Address> retrieveMembersAddresses(Nullable<int> selectedMemberId, MergeOption mergeOption)
        {
            var selectedMemberIdParameter = selectedMemberId.HasValue ?
                new ObjectParameter("selectedMemberId", selectedMemberId) :
                new ObjectParameter("selectedMemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Address>("retrieveMembersAddresses", mergeOption, selectedMemberIdParameter);
        }
    }
}
