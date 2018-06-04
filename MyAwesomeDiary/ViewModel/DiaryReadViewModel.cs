using MyAwesomeDiary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyAwesomeDiary.ViewModel
{
    public class DiaryReadViewModel: BaseViewModel
    {
        public ICommand OpenDiaryWriteCommand { get; set; }
        public ICommand OpenReadingDiaryCommand { get; set; }
        public ICommand UpdateDiaryCommand { get; set; }
        public ICommand DeleteDiaryCommand { get; set; }
        public DiaryReadViewModel()
        {
            OpenDiaryWriteCommand = new RelayCommand<DiaryReadView>(p => { return true; }, p =>
            {
                DiaryWriteView dwv = new DiaryWriteView(p.mainUser);
                dwv.ShowDialog();
                p.lwListDiary.ItemsSource = GetListDiary(p.mainUser);
            });
            OpenReadingDiaryCommand = new RelayCommand<DiaryReadView>(p => { return true; }, p =>
            {
                try
                {
                    ReadingDiaryView rdw;
                    int id = ((Diary)p.lwListDiary.SelectedItem).DiaryID;
                    rdw = new ReadingDiaryView(id);
                    rdw.ShowDialog();
                    p.lwListDiary.ItemsSource = GetListDiary(p.mainUser);
                }
                catch
                {
                    MessageBox.Show("Bạn phải chọn nhật ký");
                }

            });
            DeleteDiaryCommand = new RelayCommand<DiaryReadView>(p => { return true; }, p =>
            {
                if (p.lwListDiary.SelectedItem == null)
                {
                    MessageBox.Show("Bạn phải chọn nhật ký");
                }
                else
                {
                    int id = ((Diary)p.lwListDiary.SelectedItem).DiaryID;
                    using (var db = new MyContext())
                    {
                        db.Diaries.Find(id).Active = false;
                        db.SaveChanges();
                    }
                    p.lwListDiary.ItemsSource = GetListDiary(p.mainUser);
                    MessageBox.Show("xóa thành công");
                }
            });
            UpdateDiaryCommand = new RelayCommand<DiaryReadView>(p => { return true; }, p =>
            {
                try
                {
                    DiaryUpdateView duv;
                    int id = ((Diary)p.lwListDiary.SelectedItem).DiaryID;
                    duv = new DiaryUpdateView(id);
                    duv.ShowDialog();
                    p.lwListDiary.ItemsSource = GetListDiary(p.mainUser);
                }
                catch
                {
                    MessageBox.Show("Bạn phải chọn nhật ký");
                }
            });
        }
        static public List<Diary> GetListDiary(User user)
        {
            List<Diary> diaries;
            using (var db = new MyContext())
            {
                diaries = (from n in db.Diaries
                           where n.UserID == user.UserID
                           && n.Active == true
                           select n).ToList();
            }
            return diaries;
        }
    }
}
