import { Routes, RouterModule } from '@angular/router';
import { LoanFormComponent } from './components/loan-form/loan-form.component';

const routes: Routes = [
  { path: '', component: LoanFormComponent }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
