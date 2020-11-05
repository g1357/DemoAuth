using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMobileClient.Models
{
    public class Dish :DishDTO
    {
        private Photo _photo;
        /// <summary>
        /// Основная фотография блюда
        /// </summary>
        public Photo Photo
        {
            get
            {
                if (_photo == null)
                {
                    if (MainPictureId > 0)
                    {
                        //_photo = _service.GetPhotoAsync(MainPictureId);
                    }
                    else
                    {
                        _photo = null;
                        // Ошибка внутренней структуры базы данных
                    }
                }
                return _photo;
            }
            set
            {
                _photo = value;
                MainPictureId = value.Id;
            }
        }

        public DishType _type;
        public DishType Type
        {
            get
            {
                if (_type == null)
                {
                    if (TypeId > 0)
                    {
                        //_type = _service.GetPhotoAsync(TypeId);
                    }
                    else
                    {
                        _type = null;
                        // Ошибка внутренней структуры базы данных
                    }
                }
                return _type;
            }
            set
            {
                _type = value;
                TypeId = value.Id;
            }
        }
    }
}