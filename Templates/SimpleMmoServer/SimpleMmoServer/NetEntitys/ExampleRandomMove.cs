﻿using GalaxyCoreCommon;
using GalaxyCoreServer;
using GalaxyCoreServer.Api;
using SimpleMmoCommon;
using SimpleMmoCommon.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMmoServer.NetEntitys
{
    public class ExampleRandomMove : NetEntity
    {
        private GalaxyVector3 target = new GalaxyVector3();
        Random rnd = new Random();
        float timer;

        public ExampleRandomMove()
        {
            name = "Move";         
            position = new GalaxyVector3();
            //   rotation = new GalaxyQuaternion();
        }

        public override void InMessage(byte externalCode, byte[] data, ClientConnection client)
        {
          
        }

        public override void OnDestroy()
        {
           
        }

        public override void Start()
        {
          syncType = NetEntityAutoSync.position_and_rotation;
        }

        public override void Update()
        {
            timer += instance.Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                target.x = rnd.Next(-60, 60);
                target.z = rnd.Next(-60, 60);
            }
           position = GalaxyVector3.Lerp(position, target, instance.Time.deltaTime*0.05f);
            /*
            position = GalaxyVector3.Lerp(position, target, instance.Time.deltaTime);
            MessageTransform message = new MessageTransform();
            message.position = position;
            SendMessage((byte)NetEntityCommand.syncTransform, message, GalaxyDeliveryType.unreliableNewest);
            */
        }

         
    }
}
