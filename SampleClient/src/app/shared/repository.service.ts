import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  

  public getProject = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.projectUrl));
  }
  public postProject = (route: string, latlong: { Name: string, IsActive: boolean, lat: number, long: number }) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl.projectUrl),latlong);
  }
  public putProject = (route: string, latlong: { ProjectId: number, Name: string, lat: number, long: number }) => {

    return this.http.put(this.createCompleteRoute(route, this.envUrl.projectUrl),latlong);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
