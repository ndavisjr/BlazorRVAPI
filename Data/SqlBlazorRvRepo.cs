using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorRVAPI.Models.Checklist;
using BlazorRVAPI.Models.Expense;
using BlazorRVAPI.Models.Inventory;

namespace BlazorRVAPI.Data
{
    public class SqlBlazorRvRepo : IBlazorRVAPIRepo
    {

        private readonly BlazorRvApiContext _context;

        public SqlBlazorRvRepo(BlazorRvApiContext context)
        {
            _context = context;
        }

        public void CreateChecklist(Checklist checklist)
        {
            if (checklist == null)
            {
                throw new ArgumentNullException(nameof(checklist));
            }

            _context.Checklists.Add(checklist);
        }

        public void CreateChecklistItem(ChecklistItem checklistItem)
        {
            if (checklistItem == null)
            {
                throw new ArgumentNullException(nameof(checklistItem));
            }

            _context.ChecklistItems.Add(checklistItem);
        }

        public void CreateExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            _context.Expenses.Add(expense);
        }

        public void CreateInventoryItem(InventoryItem inventoryItem)
        {
            if (inventoryItem == null)
            {
                throw new ArgumentNullException(nameof(inventoryItem));
            }

            _context.InventoryItems.Add(inventoryItem);
        }

        public void DeleteChecklist(Checklist checklist)
        {
            if (checklist == null)
            {
                throw new ArgumentNullException(nameof(checklist));
            }

            _context.Checklists.Remove(checklist);
        }

        public void DeleteChecklistItem(ChecklistItem checklistItem)
        {
            if (checklistItem == null)
            {
                throw new ArgumentNullException(nameof(checklistItem));
            }

            _context.ChecklistItems.Remove(checklistItem);
        }

        public void DeleteExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            _context.Expenses.Remove(expense);
        }

        public void DeleteInventoryItem(InventoryItem inventoryItem)
        {
            if (inventoryItem == null)
            {
                throw new ArgumentNullException(nameof(inventoryItem));
            }

            _context.InventoryItems.Remove(inventoryItem);
        }

        public IEnumerable<ChecklistItem> GetAllChecklistItems()
        {
            return _context.ChecklistItems.ToList();
        }

        public IEnumerable<Checklist> GetAllChecklists()
        {
            return _context.Checklists.ToList();
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses.ToList();
        }

        public IEnumerable<InventoryItem> GetAllInventoryItems()
        {
            return _context.InventoryItems.ToList();
        }

        public Checklist GetChecklistById(int id)
        {
            return _context.Checklists.FirstOrDefault(p => p.Id == id);
        }

        public ChecklistItem GetChecklistItemById(int id)
        {
            return _context.ChecklistItems.FirstOrDefault(p => p.Id == id);
        }

        public Expense GetExpenseById(int id)
        {
            return _context.Expenses.FirstOrDefault(p => p.Id == id);
        }

        public InventoryItem GetInventoryItemById(int id)
        {
            return _context.InventoryItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateChecklist(Checklist checklist)
        {
            //nothing to do in SQL Server implementation
        }

        public void UpdateChecklistItem(ChecklistItem checklistItem)
        {
            //nothing to do in SQL Server implementation
        }

        public void UpdateExpense(Expense expense)
        {
            //nothing to do in SQL Server implementation
        }

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            //nothing to do in SQL Server implementation
        }
    }
}