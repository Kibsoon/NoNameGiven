renderer.material.color = Color.grey;

function OnMouseEnter () 
{
	renderer.material.color = Color.white;
}

function OnMouseExit () 
{
	renderer.material.color = Color.grey;
}

function Update()
{
	if(Input.GetKey(KeyCode.Escape)) Application.Quit();
}

//function OnMouseUp()
//{
//	if()
//}