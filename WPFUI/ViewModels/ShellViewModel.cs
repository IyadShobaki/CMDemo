using Caliburn.Micro;
using DemoLibrary;
using DemoLibrary.Models;
using System.ComponentModel;
using System.Linq;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }

        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }

        public void AddPerson()
        {
            DataAccess dataAccess = new DataAccess();
            int maxId = 0;
            if (People.Count > 0)
            {
                maxId = People.Max(x => x.PersonId);  
            }
            People.Add(dataAccess.GetPerson(maxId + 1));

        }
        public void RemovePerson()
        {
            DataAccess dataAccess = new DataAccess();
            if (People.Count == 0)
            {
                return;
            }
            PersonModel randomPerson = dataAccess.GetRandomItem<PersonModel>(People.ToArray());
            People.Remove(randomPerson);
        }
      
    }
}


//Code for the ComboBox lesson-----------------------

//private PersonModel _selectedPerson;

//public PersonModel SelectedPerson
//{
//    get { return _selectedPerson; }
//    set
//    {

//        _selectedPerson = value;
//        SelectedAddress = value.PrimaryAddress;
//        NotifyOfPropertyChange(() => SelectedPerson);

//    }
//}

//private AddressModel _selectedAddress;

//public AddressModel SelectedAddress
//{
//    get { return _selectedAddress; }
//    set
//    {
//        _selectedAddress = value;
//        SelectedPerson.PrimaryAddress = value;
//        NotifyOfPropertyChange(() => SelectedAddress);

//    }
//}



//Code for first lesson WPF  ----------------------------------

//using Caliburn.Micro;
//using WPFUI.Models;

//namespace WPFUI.ViewModels
//{
//    public class ShellViewModel : Conductor<object>
//    {
//        private string _firstName = "Iyad";
//        private string _lastName;
//        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
//        private PersonModel _selectedPerson;

//        public ShellViewModel()
//        {
//            People.Add(new PersonModel { FirstName = "Iyad", LastName = "Shobaki" });
//            People.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
//            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
//        }
//        public string FirstName
//        {
//            get
//            {
//                return _firstName;
//            }
//            set
//            {
//                _firstName = value;
//                NotifyOfPropertyChange(() => FirstName);
//                NotifyOfPropertyChange(() => FullName);
//            }
//        }

//        public string LastName
//        {
//            get
//            {
//                return _lastName;
//            }
//            set
//            {
//                _lastName = value;
//                NotifyOfPropertyChange(() => LastName);
//                NotifyOfPropertyChange(() => FullName);
//            }
//        }

//        public string FullName
//        {
//            get
//            {
//                return $"{ FirstName } { LastName }";
//            }
//        }

//        public BindableCollection<PersonModel> People
//        {
//            get { return _people; }
//            set { _people = value; }
//        }

//        public PersonModel SelectedPerson
//        {
//            get { return _selectedPerson; }
//            set
//            {
//                _selectedPerson = value;
//                NotifyOfPropertyChange(() => SelectedPerson);
//            }
//        }

//        public bool CanClearText(string firstName,
//            string lastName)// => !string.IsNullOrWhiteSpace(firstName) || !string.IsNullOrWhiteSpace(lastName);
//        {
//            //return !string.IsNullOrWhiteSpace(firstName) || !string.IsNullOrWhiteSpace(lastName);
//            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }
//        public void ClearText(string firstName, string lastName)
//        {
//            FirstName = "";
//            LastName = "";
//        }

//        public void LoadPageOne()
//        {
//            ActivateItem( new FirstChildViewModel());
//        }

//        public void LoadPageTwo()
//        {
//            ActivateItem(new SecondChildViewModel());
//        }

//    }
//}
