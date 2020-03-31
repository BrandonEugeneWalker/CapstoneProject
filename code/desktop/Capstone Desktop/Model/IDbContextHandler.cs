using System.Collections.Generic;
using System.ComponentModel;
using Capstone_Database.Model;

namespace Capstone_Desktop.Model
{
    /// <summary>
    ///   <para>The IDbContextHandler defines a contract for interfacing with a Database.</para>
    ///   <para>This allows for us to more easily mock and test interactions with the database.</para>
    /// </summary>
    public interface IDbContextHandler
    {
        //Getters

        List<DetailedRentalView> GetDetailedEmployeeHistory(Employee employee);

        List<DetailedRentalView> GetDetailedStockHistory(Stock stock);

        Employee GetEmployeeByIdAndPassword(int id, string password);

        BindingList<Employee> GetAllEmployees();

        List<StockDetailView> GetAllDetailedStock();

        List<DetailedRentalView> GetDetailedRentalsWaitingShipment();

        List<DetailedRentalView> GetDetailedRentalsWaitingReturn();

        BindingList<DetailedRentalView> GetAllDetailedRentals();

        ItemRental GetItemRentalById(int id);

        ItemRental GetStockById(int id);

        //Removals

        void RemoveEmployee(Employee employee);

        void RemoveStock(Stock stock);

        //Insertions

        void AddStock(Stock stock);

        void AddEmployee(Employee employee);

        //Modifications

        bool MarkRentalAsWaitingReturn(DetailedRentalView detailedRentalView);

        bool MarkRentalAsReturned(DetailedRentalView detailedRentalView);

    }
}