import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoanService, LoanRequest, LoanResponse} from '../../Services/loan.service';

@Component({
  selector: 'app-loan-form',
  templateUrl: './loan-form.component.html',
  styleUrls: ['./loan-form.component.css']
})
export class LoanFormComponent {
  loanForm: FormGroup;
  loanResult: LoanResponse | null = null;
  errorMessage: string | null = null;

  constructor(private fb: FormBuilder, private loanService: LoanService) {
    this.loanForm = this.fb.group({
      clientId: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      amount: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      periodInMonths: ['', [Validators.required, Validators.pattern('^[0-9]*$')]]
    });
  }

  onSubmit(): void {
    if (this.loanForm.valid) {
      const request: LoanRequest = this.loanForm.value;

      this.loanService.calculateLoan(request).subscribe({
        next: (response) => {
          this.loanResult = response;
          this.errorMessage = null;
        },
        error: (err) => {
          this.loanResult = null;
          this.errorMessage = 'An error occurred while calculating the loan. Please try again.';
          console.error('Loan error:', err);
        },
        complete: () => {
          console.log('Loan calculation completed');
        }
      });
    } else {
      this.errorMessage = 'Please fill out the form correctly.';
    }
  }
}
