using UnityEngine;

namespace Pattern.Visitor
{
    public class ClientVisitor : MonoBehaviour
    {
        //these are the scriptable objects
        public PowerUp enginePowerUp;
        public PowerUp shieldPowerUp;
        public PowerUp weaponPowerUp;
        public PowerUp superPowerUp;
        
        private BikeController _bikeController;

        void Start()
        {
            _bikeController = 
                gameObject.
                    AddComponent<BikeController>();
        }

        //each accept technically visits each thing, but only has an effect on certain parts of the bike
        void OnGUI()
        {
            if (GUILayout.Button("PowerUp Shield"))
                _bikeController.Accept(shieldPowerUp);

            if (GUILayout.Button("PowerUp Engine"))
                _bikeController.Accept(enginePowerUp);
            
            if (GUILayout.Button("PowerUp Weapon"))
                _bikeController.Accept(weaponPowerUp);

            if (GUILayout.Button("PowerUp All"))
                _bikeController.Accept(superPowerUp);
        }
    }
}