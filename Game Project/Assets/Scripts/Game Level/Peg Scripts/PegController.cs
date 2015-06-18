﻿using UnityEngine;
using System.Collections;

public class PegController : MonoBehaviour {

	
	public PegStateMachine pegState;

	public PegTypeMach PegType;

	// Use this for initialization
	void Start () 
	{
		//pegState = this.gameObject.GetComponent<PegStateMachine>();

		if(GameManger.ACTIVE == false ){
			pegState.moveIn = false;
		}
	}
		
	void OnTouchDown()
	{
		if(ItemBar.ItemSelectionMode == false)
		{

		//if a block is full, when click on check if there are any other active blocks. if not set to active
		if(pegState.blockState != PegStateMachine.BlockState.Active && GameManger.ACTIVE == false && PegType.blockType != PegTypeMach.BlockType.Empty)
		{
			pegState.blockState = PegStateMachine.BlockState.Active;
			//GameManger.CURRENT_OPEN_BLOCK.moveIn = false;
			
		}else if(pegState.blockState == PegStateMachine.BlockState.Active)
		{
			// if this block is active when clicked on de-activeate it
			GameManger.ACTIVE = false;
			GameManger.CURRENT_OPEN_BLOCK.moveIn = false;
			pegState.blockState = PegStateMachine.BlockState.Normal;
			
			//if this block a empty block and another  block is  active, check  if this block can be moved into
		}else if( GameManger.ACTIVE == true && PegType.blockType == PegTypeMach.BlockType.Empty && pegState.moveIn == true)
		{
			GameManger.ACTIVE = false;
			pegState.blockState = PegStateMachine.BlockState.Move;

		}
		
		pegState.ChangeBlockState();
		//Debug.Log("Click!");

		}else{

			//attach item

			ItemBar.PegAttachObject = this.gameObject;

			Messenger.Broadcast< bool >("Set Selection Mode", true);

		}
	}
	
	void OnTouchUp()
	{
//		//Debug.Log("Drag ended!");
//		if(pegState.blockState != PegStateMachine.BlockState.Uncapable)
//		{
//			
//		}

		if( ItemBar.ItemSelectionMode == true)
		{
		Messenger.Broadcast< bool >("Set Selection Mode", false);
		}

	}

	void OnTouchStay()
	{

	}
	
	void OnTouchExit()
	{

		if(ItemBar.ItemSelectionMode == false)
		{
				if(pegState.blockState != PegStateMachine.BlockState.Active && pegState.blockState != PegStateMachine.BlockState.Uncapable )
				{
					pegState.blockState = PegStateMachine.BlockState.Normal;
					pegState.ChangeBlockState();
				}
				
				//if active set empty blocks back false
				if(GameManger.ACTIVE == false){
					pegState.moveIn = false;
				}
		}else{
			// exit mode
			Messenger.Broadcast< bool >("Set Selection Mode", false);
		}
	}

}
