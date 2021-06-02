﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTakerApi.Services
{
    public class NoteStorage : ICloneable
    {
        private Dictionary<int, Models.Note> notes;
        private int idCounter;

        public NoteStorage()
        {
            notes = new Dictionary<int, Models.Note>();
            idCounter = 0;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool ContainsId(int id)
        {
            return notes.ContainsKey(id);
        }

        public void Delete(int id)
        {
            notes.Remove(id);
        }

        public void Update(int id, Models.Note note)
        {
            notes[id].Text = note.Text;
        }

        public int CreateNew(Models.Note note)
        {
            var newNote = new Models.Note
            {
                Id = GetNextId(),
                Text = note.Text
            };

            notes.Add(newNote.Id, newNote);

            return newNote.Id;
        }

        public List<Models.Note> GetAll()
        {
            return notes.Values.ToList();
        }

        public int GetNextId()
        {
            return ++idCounter;
        }
    }
}