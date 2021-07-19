using System.Collections.Generic;
using BlazorRVAPI.Models.Checklist;
using BlazorRVAPI.Models.Inventory;
using BlazorRVAPI.Models.Expense;

namespace BlazorRVAPI.Data
{
    public interface IBlazorRVAPIRepo
    {
        bool SaveChanges();

        // Checklists
        IEnumerable<Checklist> GetAllChecklists();
        Checklist GetChecklistById(int id);
        void CreateChecklist(Checklist checklist);
        void UpdateChecklist(Checklist checklist);
        void DeleteChecklist(Checklist checklist);

        // ChecklistItes
        IEnumerable<ChecklistItem> GetAllChecklistItems();
        ChecklistItem GetChecklistItemById(int id);
        void CreateChecklistItem(ChecklistItem checklistItem);
        void UpdateChecklistItem(ChecklistItem checklistItem);
        void DeleteChecklistItem(ChecklistItem checklistItem);

        // Inventory
        IEnumerable<InventoryItem> GetAllInventoryItems();
        InventoryItem GetInventoryItemById(int id);
        void CreateInventoryItem(InventoryItem inventoryItem);
        void UpdateInventoryItem(InventoryItem inventoryItem);
        void DeleteInventoryItem(InventoryItem inventoryItem);

        //Budgeting
        IEnumerable<Expense> GetAllExpenses();
        Expense GetExpenseById(int id);
        void CreateExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(Expense expense);
    }
}