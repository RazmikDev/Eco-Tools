using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Eco.Collections
{
	public class BitArray : IEnumerable<int>
	{
		private const int SLOT_SIZE_IN_BYTES = sizeof(int);
		private const int SLOT_SIZE_IN_BITS = SLOT_SIZE_IN_BYTES * 8;
		private readonly int[] m_innerArray;
		private int m_count;

		public BitArray(int length)
		{
            this.Length = length;
            int slotsCount = this.Length / SLOT_SIZE_IN_BITS;
            int overBits = this.Length % SLOT_SIZE_IN_BITS;
            if (overBits > 0) { ++slotsCount; }
            this.m_innerArray = new int[slotsCount];
		}		 

		public int Size
		{
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
            	return this.m_innerArray.Length * SLOT_SIZE_IN_BYTES;
            }
		}

		public int Length
		{
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
		}

		public int Count
		{
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.m_count;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private set
            {
            	this.m_count = value;
            }
		}


		public bool this[int index]
		{
            get
            {
            	int slotIndex = index / SLOT_SIZE_IN_BITS;
            	int bitNumber = index % SLOT_SIZE_IN_BITS;
            	int slotValue = this.m_innerArray[slotIndex];
            	int flag = 1 << bitNumber;
            	return (slotValue & flag) == flag;
            }
            set
            {
            	Set(index, value);
            }
		}

		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
            return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
            return GetEnumerator();
		}

		public bool Set(int index, bool value = true)
		{
            int slotIndex = index / SLOT_SIZE_IN_BITS; // get 32 bit slot index
            int bitNumber = index % SLOT_SIZE_IN_BITS; // get index of the bit within slot
            int slotValue = this.m_innerArray[slotIndex]; // get current slot value

            // determine flag mask
            int flag = 1 << bitNumber;

            // if the same flag is set - return
            bool hasFlag = (slotValue & flag) == flag;
            if (hasFlag == value) { return false;}

            // apply flag 
            slotValue = value
            	? slotValue | flag
            	: slotValue & ~flag;

            // save
            this.m_innerArray[slotIndex] = slotValue;

            // count
            if (value)
            { ++this.Count;}
            else
            { --this.Count;}

            return true;
		}

		public Enumerator GetEnumerator()
		{
            return new Enumerator(this);
		}

		public void Clear()
		{
            Array.Clear(this.m_innerArray, index: 0, length: this.m_innerArray.Length);
            this.Count = 0;
		}

		public struct Enumerator : IEnumerator<int>
		{
            private readonly int[] m_innerArray;
            private int m_currentSlotValue;
            private int m_currentSlotIndex;
            private int m_currentBitNumber;
            private readonly int m_maxSlotIndex;
            private int m_current;

            public Enumerator(BitArray bitArray)
            {
            	this.m_innerArray = bitArray.m_innerArray;
            	this.m_maxSlotIndex = this.m_innerArray.Length - 1;
            	this.m_current = default(int);
            	this.m_currentBitNumber = -1;
            	this.m_currentSlotIndex = 0;
            	this.m_currentSlotValue = 0;
            }

            public int Current
            {
            	get
            	{
            		return this.m_current;
            	}
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
            	unchecked
            	{
            		for (; this.m_currentSlotIndex <= this.m_maxSlotIndex; ++this.m_currentSlotIndex)
            		{
                        int slotValue = this.m_currentBitNumber < 0 // if slot number is changed
                        	? (this.m_currentSlotValue = this.m_innerArray[this.m_currentSlotIndex])
                        	: this.m_currentSlotValue;

                        if (slotValue == 0) { continue; }

                        const int limit = SLOT_SIZE_IN_BITS - 1;
                        while (this.m_currentBitNumber < limit)
                        {
                        	++this.m_currentBitNumber;

                        	int flag = 1 << this.m_currentBitNumber;
                        	bool hasValue = (slotValue & flag) == flag;
                        	if (!hasValue) { continue; } // go and examine next bit number

                        	// has value
                        	this.m_current = this.m_currentSlotIndex * SLOT_SIZE_IN_BITS + this.m_currentBitNumber;
                        	return true;
                        }

                        // go to next slot
                        this.m_currentBitNumber = -1;
            		}
            	}

            	return false;
            }

            public void Reset()
            {
            	this.m_currentBitNumber = -1;
            	this.m_currentSlotIndex = 0;
            	this.m_currentSlotValue = 0;
            	this.m_current = default(int);
            }

            public void Dispose()
            {
            }
		}
	}
}