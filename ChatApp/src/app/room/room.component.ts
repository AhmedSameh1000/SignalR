import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessagesService } from '../Services/messages.service';
import { SignalRService } from '../Services/signal-r.service';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit{
    constructor(private Route:ActivatedRoute,
      private MessageService:MessagesService,
      private SignalR:SignalRService){
      
    }
    ngOnInit() {
      this.SignalR.startConnection()
      this.loadparams()
      this.LoadMessagesInSpasificRoom()
    
      this.SignalR.HubConnection.on("Data",(res)=>{
        console.log(res)
        //res this is the message come from server you can push it to Mesages list or 
        //load Meesages again 
        this.LoadMessagesInSpasificRoom()
      })
    }
    RoomId!:number
    loadparams(){
      this.Route.params.subscribe(params => {
        this.RoomId = params['id'];
      });
    }

    MessageToSend:string=''
    Messages:any
  LoadMessagesInSpasificRoom(){

    this.MessageService.GetMessagesinSpasificRoom(this.RoomId)
    .subscribe(res=>{
      this.Messages=res
    })

  }

  SendMessage(){
    var messageTo={
      RoomId:this.RoomId,
      Message:this.MessageToSend
    }
    this.MessageService.SendMessageInSpasificGroup(messageTo)
    .subscribe(res=>{
      console.log(res)
      this.SignalR.HubConnection.invoke("Refresh",this.MessageToSend).then(()=>{
      })
      this.MessageToSend=''
    })
  }
}
