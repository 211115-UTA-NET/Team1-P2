export interface NewExpense
{
    id: string;
    name: string;
    frequency: string;
    priority: string;
}

export interface GetExpense
{
    name: string;
    frequency: string;
    priority: string;
}