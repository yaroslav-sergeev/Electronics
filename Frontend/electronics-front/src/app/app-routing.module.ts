import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  //{ path: '', redirectTo: '/header', pathMatch: 'full' },
  //{ path: 'dashboard', component: DashboardComponent },
  // { path: '/category/:name', component: DashboardComponent },
  // { path: '/brand/:name', component: DashboardComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}

