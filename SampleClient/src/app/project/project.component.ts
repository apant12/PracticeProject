

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../shared/repository.service';

export interface Project {
  address: string
  isActive: boolean
  name: string
  projectId: number
  lat: number
  long: number
  
}


@Component({
  selector: 'app-companies',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  
  public projects: Project[];

  constructor(private repository: RepositoryService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getProject();
    
  }

  public getProject = () => {
    const apiAddress: string = "api/project";
    this.repository.getProject(apiAddress)
    .subscribe(res => {
      console.log(this.projects)
      this.projects = res as Project[]; 
    })
  }

  public onLatLongUpdate(latlong: { ProjectId: number, Name: string, lat: number, long: number }) {
    if (latlong.ProjectId === null || latlong.lat === null || latlong.long == null) {
      alert("The projectId or lat or long cannot be blank.Thank You!")
    }
    const id = latlong.ProjectId;
    const { ProjectId, lat, long } = latlong;
    const currentProject: Project = this.projects.find((project) => project.projectId === id) as Project;
    currentProject.lat = Number(lat.toFixed(2));
    currentProject.long = Number(long.toFixed(2));
    const apiAddress: string = "api/project/" + id.toString();
    this.repository.putProject(apiAddress, currentProject as any)
      .subscribe(res => {
        console.log(currentProject)
        
      })
  }

  public onAddProject(latlong: {Name: string, IsActive: boolean, lat: number, long: number }) {
    const apiAddress: string = "api/project";
    console.log(latlong);
    this.repository.postProject(apiAddress, latlong)
      .subscribe(res => {
        console.log(this.projects)
       
      })
    
  }
}
