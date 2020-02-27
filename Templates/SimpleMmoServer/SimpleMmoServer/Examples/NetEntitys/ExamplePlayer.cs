﻿using GalaxyCoreServer;
using GalaxyCoreCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMmoServer.Examples.NetEntitys
{
    public class ExamplePlayer : NetEntity
    {

        ExamplePet pet;
      
        public override void InMessage(byte externalCode, byte[] data, Client client)
        {
         
        }

        public override void OnDestroy()
        {
            instance.entities.RemoveNetEntity(pet);  
        }

        public override void Start()
        {
            Log.Info("ExamplePlayer", "Start");
            autoApplyRemoteTransform = true;
            syncType = NetEntityAutoSync.position_and_rotation;
            pet = new ExamplePet();
            pet.player = this;
            instance.entities.CreateNetEntity(pet);
        }

        public override void Update()
        {
           
        }
    }
}
