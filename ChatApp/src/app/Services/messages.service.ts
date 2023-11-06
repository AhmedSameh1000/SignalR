import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class MessagesService {
  BaseUrl="https://localhost:7150/api/Messages/"   
  constructor(private HttpClien:HttpClient) { }

  public SendMessageInSpasificGroup(Message:any){
    return this.HttpClien.post(this.BaseUrl+`SendMessage`,Message)
  }
  public GetAllRomes(){
    return this.HttpClien.get(this.BaseUrl+"GetAllRooms")
  }
  public CreateRoom(Room:any){
    return this.HttpClien.post(this.BaseUrl+`CreateRoom`,Room)
  }
  public GetMessagesinSpasificRoom(RoomId:number){
    return this.HttpClien.get(this.BaseUrl+`GetMessagesinSpasificRoom/${RoomId}`)
  }
}
