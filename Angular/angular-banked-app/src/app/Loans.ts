export interface Loan
{
    id: number;
    userPasswordId: number;
    loanName: string;
    loanAmount: number;
    loanInterest: number;
    monthlyPayments: number;
}