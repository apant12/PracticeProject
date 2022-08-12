
import { Injectable } from '@angular/core';
import { environment } from './environment';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentUrlService {
  
  public projectUrl: string = environment.projectAddress;
  constructor() { }
}
