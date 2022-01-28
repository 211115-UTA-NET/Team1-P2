export interface Expense
{
    id: number;
    userPassId: number;
    userOptionsId: number;
    expenseAmount: number;
    expenseFrequency: number;
    expenseEnding: string;
    priority: number;
    expenseName: string;
}