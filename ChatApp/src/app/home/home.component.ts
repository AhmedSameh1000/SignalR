import { Component } from '@angular/core';
import { MessagesService } from '../Services/messages.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private MessageService:MessagesService){
  
  }
  ngOnInit(): void {
   this.LoadRooms()
  }
  title = 'ChatApp';
  RoomName:string=''
  Rooms:any
  CreateRoom(){
    let room={
      Name:this.RoomName
    }
    this.MessageService.CreateRoom(room).subscribe({
      next:(res)=>{
        console.log(res)
        this.RoomName=""
        this.LoadRooms()
      },
      error:(err)=>console.log(err)
    })
  }
  LoadRooms(){
    this.MessageService.GetAllRomes().subscribe(res=>{
      this.Rooms=res
      console.log(res)
    })
  }
}
